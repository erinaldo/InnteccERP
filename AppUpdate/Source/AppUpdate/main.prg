#Define APPUPDATEINI "AppUpdate.ini"
#Define CRLF_X2 CHR(13) + CHR(10) + CHR(13) + CHR(10)
Local lcPath, lcAppName, loOldIniReg, lcVersionUrl, lcUpdateUrl, lcJustPathVersionUrl, lcJustPathUpdateUrl, ;
	lcMessageCaption, lcMessage, lnNewVersion, lnCurrentVersion, loDownloadForm, lcRemindedOn, lcRemindIn, ;
	lcApplicationPath, lcCaption, lcTitle, lcMessageLine1, lcMessageLine2, lcMessageLine3, lcMessage, ;
	lcReminderList, lcUpdateVersionFile, lcCopyUpdateTo, lcScriptExtension, lcIniFileFullPath, lcShellOperation, ;
	lcRunApplicationAsAdmin, lcApplicationCommmandLineParams, lnShellReturn
STORE "" TO lcPath, lcAppName, lcVersionUrl, lcUpdateUrl, lcJustPathVersionUrl, lcJustPathUpdateUrl, ;
	lcMessageCaption, lcMessageloDownloadForm, lcRemindedOn, lcRemindIn, ;
	lcApplicationPath, lcCaption, lcTitle, lcMessageLine1, lcMessageLine2, lcMessageLine3, lcMessage, ;
	lcReminderList, lcUpdateVersionFile, lcCopyUpdateTo, lcScriptExtension, lcIniFileFullPath, lcShellOperation, ;
	lcRunApplicationAsAdminm, lcApplicationCommmandLineParams
*!* For Debug Only
*!*	IF _vfp.StartMode = 0
*!*		SET PATH TO (HOME() + "FFC\") ADDITIVE
*!*		SET PATH TO ("c:\work\billable\appupdate") ADDITIVE
*!*	ENDIF
SetupEnvironment()
On Error Do SHOWERROR With Error(), Message(), Message(1), Program(), Lineno()
m.lcPath = GetApplicationPath()
Set Default To (m.lcPath)
m.lcIniFileFullPath = m.lcPath + APPUPDATEINI
*!* For Debug Only
*!*	IF _vfp.StartMode = 0
*!*		SET STEP ON
*!*		SET DEFAULT TO ("c:\work\billable\appupdate\sampleapp")
*!*		m.lcIniFileFullPath = "c:\work\billable\appupdate\sampleapp\" + APPUPDATEINI
*!*	ENDIF
If File(m.lcIniFileFullPath)
	m.loOldIniReg = Createobject("oldinireg")
	m.loOldIniReg.GetIniEntry(@m.lcAppName, "UPDATE", "applicationtoupdate", m.lcIniFileFullPath)
	m.lcApplicationPath = m.lcPath + m.lcAppName
	m.loOldIniReg.GetIniEntry(@m.lcVersionUrl, "UPDATE", "versionsource", m.lcIniFileFullPath)
	m.loOldIniReg.GetIniEntry(@m.lcUpdateUrl, "UPDATE", "updatesource", m.lcIniFileFullPath)
	m.lcJustPathVersionUrl = Justpath(m.lcVersionUrl)
	m.lcJustPathUpdateUrl = Justpath(m.lcUpdateUrl)
*!* ensure that we have access to the update server
	If ServerIsAvailable(m.lcJustPathVersionUrl) AND (m.lcJustPathVersionUrl = m.lcJustPathUpdateUrl OR ServerIsAvailable(m.lcJustPathUpdateUrl))
		m.lnNewVersion = GetUpdateVersionNumber(m.lcVersionUrl, @m.lcUpdateVersionFile) && version number of the latest update on server
		m.lnCurrentVersion = GetApplicationVersionNumber(m.lcApplicationPath)
		If m.lnNewVersion > m.lnCurrentVersion && is the version on the server > the version on the user's computer?
			m.loOldIniReg.GetIniEntry(@m.lcRemindedOn, "REMINDER", "remindedon", m.lcIniFileFullPath)
			m.loOldIniReg.GetIniEntry(@m.lcRemindIn, "REMINDER", "remindin", m.lcIniFileFullPath)
			IF ShouldRemindUser(m.lcRemindedOn, m.lcRemindIn)
				m.loOldIniReg.GetIniEntry(@m.lcReminderList, "REMINDER", "options", m.lcIniFileFullPath)
				m.loOldIniReg.GetIniEntry(@m.lcCaption, "MESSAGE", "caption", m.lcIniFileFullPath)
				m.loOldIniReg.GetIniEntry(@m.lcTitle, "MESSAGE", "title", m.lcIniFileFullPath)
				m.loOldIniReg.GetIniEntry(@m.lcMessageLine1, "MESSAGE", "messageline1", m.lcIniFileFullPath)
				m.loOldIniReg.GetIniEntry(@m.lcMessageLine2, "MESSAGE", "messageline2", m.lcIniFileFullPath)
				m.loOldIniReg.GetIniEntry(@m.lcMessageLine3, "MESSAGE", "messageline3", m.lcIniFileFullPath)
				m.lcMessage = m.lcMessageLine1 + CRLF_X2 + m.lcMessageLine2 + CRLF_X2 + m.lcMessageLine3
				m.loOldIniReg.GetIniEntry(@m.lcCopyUpdateTo, "UPDATE", "copyupdateto", m.lcIniFileFullPath)
				m.loOldIniReg.GetIniEntry(@m.lcScriptExtension, "SCRIPT", "extension", m.lcIniFileFullPath)
				_screen.AddProperty("nDownloadReturn",0)
				m.loDownloadForm = CREATEOBJECT("updatemessage", m.lcCaption, m.lcTitle, m.lcMessage, m.lcUpdateUrl, ;
												m.lcReminderList, m.lcPath, m.lcCopyUpdateTo, m.lcVersionUrl, m.lcUpdateVersionFile, ;
												m.lcScriptExtension,lncurrentversion,lnnewversion)
				m.loDownloadForm.Show()
				READ EVENTS
				DO CASE
*!*					CASE _screen.nDownloadReturn = 0 && No Thanks, reminder not set
*!*						*!* Do Nothing
				CASE _screen.nDownloadReturn > 0 && No Thanks, reminder set
					SetReminder(_screen.nDownloadReturn, m.lcIniFileFullPath, m.loOldIniReg)
				OTHERWISE && -1 Download and Install
				ENDCASE
			ENDIF
		ENDIF
		IF FILE(m.lcUpdateVersionFile)
			ERASE (m.lcUpdateVersionFile)
		ENDIF
	ENDIF
	
	m.loOldIniReg.GetIniEntry(@m.lcRunApplicationAsAdmin, "UPDATE", "runapplicationasadmin", m.lcIniFileFullPath)
	m.lcShellOperation = ICASE(EMPTY(m.lcRunApplicationAsAdmin), "Open", UPPER(ALLTRIM(m.lcRunApplicationAsAdmin)) = "TRUE", "runas", "Open")
	m.loOldIniReg.GetIniEntry(@m.lcApplicationCommmandLineParams, "UPDATE", "applicationcommandlineparams", m.lcIniFileFullPath)
*!* Attempt to start the application
	Declare Integer ShellExecute In shell32;
		INTEGER HWnd,;
		STRING  lpOperation,;
		STRING  lpFile,;
		STRING  lpParameters,;
		STRING  lpDirectory,;
		INTEGER nShowCmd

	On Error * && just ignore any errors from here to the end of the prg
	m.lnShellReturn = ShellExecute(0, m.lcShellOperation, m.lcApplicationPath, m.lcApplicationCommmandLineParams, m.lcPath,1)
Endif

If _vfp.StartMode = 0 && Running in IDE - debug mode
	Cancel
Else
	Quit
Endif

*************************************
FUNCTION ShouldRemindUser(tcRemindedOn, tcRemindIn)
*************************************
	LOCAL llReturn, ltRemindedOn, lnRemindIn
	m.llReturn = .T.
	IF !EMPTY(tcRemindedOn) AND !EMPTY(tcRemindIn)
		m.ltRemindedOn = CTOT(m.tcRemindedOn)
		m.lnRemindIn = VAL(tcRemindIn) * 60
		m.llReturn = (DATETIME() > (m.ltRemindedOn + m.lnRemindIn))
	ENDIF
	RETURN m.llReturn
ENDFUNC

*************************************
PROCEDURE SetReminder(tnRemindIn, tcIniFile, toOldIniReg)
*************************************
	m.toOldIniReg.writeinientry(TTOC(DATETIME()), "REMINDER", "remindedon", m.tcIniFile)
	m.toOldIniReg.writeinientry(TRANSFORM(tnRemindIn), "REMINDER", "remindin", m.tcIniFile)
ENDPROC

*************************************
Procedure SetupEnvironment()
*************************************
Set Decimals To 3
Set Console Off
Set Classlib To AppUpdate.vcx ADDITIVE
Set Classlib To registry.vcx ADDITIVE
_screen.WindowState = 2
Endproc

*************************************
Function GetApplicationPath()
*************************************
Return Addbs(Justpath(Sys(16,0)))
Endfunc

*************************************
Function GetUpdateVersionNumber(tcVersionUrl, tcUpdateVersionFile)
*************************************
Local lnReturn
m.lnReturn = 0.00
Declare Integer URLDownloadToFile In urlmon.Dll;
	INTEGER pCaller,;
	STRING  szURL,;
	STRING  szFileName,;
	INTEGER dwReserved,;
	INTEGER lpfnCB
m.tcUpdateVersionFile = Addbs(Sys(2023)) + Sys(2015) + ".txt" && temporary file created locally so server version can be read
*!* Attempt to get the Version file from the server
URLDownloadToFile(0, tcVersionUrl, m.tcUpdateVersionFile, 0, 0)
If File(m.tcUpdateVersionFile)
	m.lnReturn = Val(Filetostr(m.tcUpdateVersionFile)) && version number of the latest update on server
Endif
Return m.lnReturn
Endfunc

*************************************
Function GetApplicationVersionNumber(tcApplicationPath)
*************************************
Local Array laVersion(4)
Local lnReturn
m.laVersion(4) = "00.00"
m.lnReturn = 0.00
If File(m.tcApplicationPath)
	=Agetfileversion(m.laVersion, m.tcApplicationPath)
	m.lnReturn = Val(m.laVersion(4)) && version number of the user's application
Endif
Return m.lnReturn
Endfunc

****************************************************************
Function GetShortPath(tcFileName)
****************************************************************
Private lnResult, lcPath

Declare Integer GetShortPathNameA In Win32API As GetShortPathName String, String, Integer

m.lcPath = Replicate(Chr(32), 165) + Chr(0)
m.lnResult = GetShortPathName(m.tcFileName, @m.lcPath, 164)

Clear Dlls GetShortPathName

Return (Left(m.lcPath, m.lnResult))
Endfunc

***************************************
Function ServerIsAvailable(tcUrlToCheck)
***************************************
Local llReturn
m.llReturn = .T.
If !Directory(tcUrlToCheck) && First check if it is a directory path, if not then assume it is an URL
	Declare Integer InternetCheckConnection In wininet;
		STRING lpszUrl,;
		INTEGER dwFlags,;
		INTEGER dwReserved
	If InternetCheckConnection(m.tcUrlToCheck, 1, 0) != 1
		m.llReturn = .F.
	Endif
Endif
Return m.llReturn
Endfunc

*************************
Function AutomateDoDownloadFile(tcSourceFile, tcDestinationFile)
*!* tcSourceFile can be just about anything... FTP, HTTP, UNC, Local Path
*!* "FTP://username:password@ipaddress_or_domain.com/FTPDir/Source.zip"
*!* "HTTP://ipaddress_or_www.domain.com/Files/Source.zip"
*!* "\\localipaddress_or_MyServer\SharedDrive\Source.zip"
*!* "C:\Source.zip"
*!*
*!* tcDestinationFile is the full path and file name you want
*!* the source file copied to, such as
*!* C:\Destination.zip
*************************
#Define WM_SETTEXT   0xC
#Define BM_CLICK   0xF5
#Define BM_SETCHECK 0xF1
#Define BST_CHECKED 0x0001

Declare DoFileDownload In shdocvw.Dll String lpszFile
Declare Integer SendMessage In user32;
	INTEGER HWnd,;
	INTEGER Msg,;
	INTEGER wParam,;
	STRING lPawram
Declare Integer FindWindow In user32 ;
	STRING lpClassName,;
	STRING lpWindowName
Local llReturn, lnHwndWindow, lnHwndControl, lcTempFile, lcSafetyWas
m.llReturn = .T.

Try
*!* Make sure the user didn't give us any invalid
*!* characters that can't appear in an URL, such as spaces
*!* if they did then FixUnsafeChars will escape them properly
	m.tcSourceFile = FixUnsafeChars(m.tcSourceFile)

	If !Empty(m.tcSourceFile)
*!* Call the magic API function here
		DoFileDownload(Strconv(m.tcSourceFile,5) + 0h0000)
	Else
		Return .F.
	Endif

	DoEvents Force
*!* rest of the code in this function is for automating
*!* the File Download and Save As dialogs...
	Store 0 To m.lnHwndWindow, m.lnHwndControl
	m.lnHwndWindow = GetWindowHandle("#32770", "Save As", .F., 1)
	If m.lnHwndWindow = 0
*!* Get the invisible download screen and make sure that the checkbox is checked
*!* so that the window will close once the download is complete
		m.lnHwndWindow = GetWindowHandle("#32770", "File Download")
		If m.lnHwndWindow != 0
			m.lnHwndControl = GetWindowHandle(m.lnHwndWindow, "BUTTON", "&Close this dialog box when download completes", 1)
			If m.lnHwndControl != 0
				SendMessage(m.lnHwndControl, BM_SETCHECK, BST_CHECKED, Null)
			Endif
		Endif
*!* Get the Save As dialog box and enter the filename
*!* into the Edit box that is provided
		m.lnHwndWindow = GetWindowHandle("#32770", "Save As")
		If m.lnHwndWindow = 0
			Return .F.
		Endif
	Endif

	If Int(Val(Os(3))) < 6 && Before Windows Vista
		m.lnHwndControl = GetWindowHandle(m.lnHwndWindow, "ComboBoxEx32", Null, 1)
	Else && Vista or higher
		m.lnHwndControl = GetWindowHandle(m.lnHwndWindow, "DUIViewWndClassName", Null, 1)
		m.lnHwndControl = GetWindowHandle(m.lnHwndControl, "DirectUIHWND", Null, 1)
		If m.lnHwndControl = 0
			Return .F.
		Endif
		m.lnHwndControl = GetWindowHandle(m.lnHwndControl, "FloatNotifySink", Null, 1)
	Endif
	If m.lnHwndControl = 0
		Return .F.
	Endif
	m.lnHwndControl = GetWindowHandle(m.lnHwndControl, "ComboBox", Null, 1)
	If m.lnHwndControl = 0
		Return .F.
	Endif
	m.lnHwndControl = GetWindowHandle(m.lnHwndControl, "Edit", Null, 1)
	If m.lnHwndControl = 0
		Return .F.
	Endif

	m.lcTempFile = Addbs(Sys(2023)) + Sys(2015) + ".tmp"
	SendMessage(m.lnHwndControl, WM_SETTEXT, 0, m.lcTempFile + 0h00)
	DoEvents Force
*!* Automatically click the Save button on the Save As dialog box
	m.lnHwndControl = GetWindowHandle(m.lnHwndWindow, "BUTTON", "&Save", 1)
	If m.lnHwndControl = 0
		Return .F.
	Endif
	SendMessage(m.lnHwndControl, BM_CLICK, 0, Null)

*!* Wait for the download to be completed by
*!* watching for the File Download window
*!* to disappear - either it downloaded or user cancelled
	Do While FindWindow("#32770", "File Download") != 0
		=Inkey(1,"H")
	Enddo
*!* if the temp file doesn't exist then something went wrong
*!* or user cancelled, so we return false
	If !File(m.lcTempFile)
		Return .F.
	Endif

*!* Copy temp file to the m.tcDestinationFile if it exists
	m.lcSafetyWas = Set("Safety")
	Set Safety Off && don't prompt for overwrite, just do it
	Copy File (m.lcTempFile) To (m.tcDestinationFile)
	Set Safety &lcSafetyWas
Catch To m.loExc
	m.llReturn = .F.
Endtry

Return m.llReturn
Endfunc

************************
Function FixUnsafeChars(tcAddressUrl)
************************
#Define ICU_BROWSER_MODE 0x2000000

Declare Integer InternetCanonicalizeUrl In wininet;
	STRING sURL, String @sBUFFER, Integer @nLength, Integer nFlags

Local lcNewUrl, lnResult, lcReturn

m.lnResult = 250
m.lcNewUrl = Replicate(Chr(0), lnResult)
m.lcReturn = ""
If InternetCanonicalizeUrl (m.tcAddressUrl,@m.lcNewUrl, @m.lnResult, ICU_BROWSER_MODE) <> 0
	m.lcReturn = Left(m.lcNewUrl, m.lnResult)
Endif
Return m.lcReturn
Endfunc

*****************************************
Function GetWindowHandle(tnParentOrClassName, tcWindowNameOrClass, tcCaption, tnTries)
*****************************************
Local lnReturn, lnCounter, llFindWindow
m.lnReturn = 0
m.llFindWindow = (Type("m.tcCaption") != "C")
If m.llFindWindow
	Declare Integer FindWindow In user32 As FindAWindow;
		STRING lpClassName,;
		STRING lpWindowName
Else
	Declare Integer FindWindowEx In user32 As FindAWindow;
		INTEGER  hwndParent,;
		INTEGER  hwndChildAfter,;
		STRING @ lpszClass,;
		STRING @ lpszWindow
Endif
If Pcount() < 4
	m.tnTries = 25
Endif
*!* Keep trying for a somewhat reasonable amount of time (approx. 6 seconds)
*!* the wait is because it takes some time to contact certain sites
*!* due to connection speed and latency
For m.lnCounter = 1 To m.tnTries
	If m.llFindWindow
		m.lnReturn = FindAWindow(m.tnParentOrClassName, m.tcWindowNameOrClass)
	Else
		m.lnReturn = FindAWindow(m.tnParentOrClassName, 0, m.tcWindowNameOrClass, m.tcCaption)
	Endif
	If m.lnReturn != 0 Or m.tnTries < 2
		Exit
	Else
		=Inkey(.25,"H")
	Endif
Endfor
Clear Dlls "FindAWindow"
Return m.lnReturn
Endfunc

*********************
Function SHOWERROR(tnError, tcMessage, tcMessage1, tcProgram, tnLineno)
*********************
#Define CRLF Chr(13)+Chr(10)
Local lcFeedback
m.lcFeedback='Error number: '+Ltrim(Str(tnError)) + CRLF;
	+'Error message: ' + tcMessage  + CRLF;
	+'Line of code with error: ' + tcMessage1 + CRLF;
	+'Line number of error: '+Ltrim(Str(tnLineno)) + CRLF;
	+ 'Program with error: ' + tcProgram
Messagebox(m.lcFeedback, 16, "ERROR HAS OCCURED")
IF _vfp.startmode = 0
	CANCEL
ELSE
	QUIT
ENDIF
Endfunc

*----------------------------------------
* ELIMINAR ARCHIVOS 
*----------------------------------------
*
* Función: DELTREE(path)
*
* Igual al DELTREE de MS-DOS, pero no pregunta
* borra un directorio completo.
*
* Parametros:
*
*		path		- path absoluto a borrar
*
* Ejemplos:
*		 llret = DELTREE("C:\TEMP\009")
*
* Retorno: 
*
*	.F. / .T. si se há conseguido borrar o no
*
FUNCTION deltree
PARAMETERS tcdirectorio

DECLARE SHORT SetFileAttributes IN KERNEL32 ;
	STRING @ lpFileName, INTEGER dwAttributes

LOCAL lcdirectorio,lamatriz, llret
DIMENSION lamatriz(1)

IF DIRECTORY(tcdirectorio,1)

	lcdirectorio="'"+tcdirectorio+"'"
	DO WHILE ADIR(lamatriz,tcdirectorio+"\*.*","HD")>2
		IF 'R'$lamatriz(3,5) OR 'H'$lamatriz(3,5) OR 'A'$lamatriz(3,5)
			SetFileAttributes(tcdirectorio+"\"+lamatriz(3,1), 0)
			DELETE FILE (tcdirectorio+"\*.*")
		ELSE
			deltree(tcdirectorio+"\"+lamatriz(3,1))
		ENDIF 
	ENDDO

	DELETE FILE(tcdirectorio+"\*.*")

	IF ADIR(lamatriz,tcdirectorio+"\*.*","HD")=2
		RMDIR &lcdirectorio
	ENDIF

	IF DIRECTORY(tcdirectorio,1)
		llret = .F.
	ELSE
		llret = .T.
	ENDIF
ELSE
	llret = .T.
ENDIF

RETURN llret
ENDFUNC

*!* Avoid compiler errors with FLL functions
*********************
Function UnzipQuick
*********************
Endfunc
*********************
Function FTPGET
*********************
Endfunc
*********************
Function HTTPGET
*********************
Endfunc
*********************
Function FILEGET
*********************
Endfunc
*********************
Function FTPPUT
*********************
Endfunc
*********************
Function HTTPPUT
*********************
Endfunc
*********************
Function FILEPUT
*********************
ENDFUNC

FUNCTION AppOpen (tcNameVentana as Character) as Boolean
	LOCAL lnVentana,llVentanaAbierta

	DECLARE INTEGER FindWindow IN user32;
    STRING lpClassName,;
    STRING lpWindowName
  
	lnVentana = FindWindow (0, tcNameVentana )

	IF lnVentana <> 0
		llVentanaAbierta = .T.
	ELSE
		llVentanaAbierta = .F.
	ENDIF 
	
	RETURN llVentanaAbierta
	
ENDFUNC 
