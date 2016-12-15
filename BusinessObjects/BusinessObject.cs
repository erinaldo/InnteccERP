using System;
using System.Collections.Generic;
using BusinessObjects.BusinessRules;
using ServiceStack.DataAnnotations;

namespace BusinessObjects
{
    // abstract business object class
    // ** Enterprise Design Pattern: Domain Model

    public abstract class BusinessObject
    {
        public int? Createdby { get; set; }
        public DateTime? Creationdate { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Lastmodified { get; set; }

        // list of business rules

        readonly List<BusinessRule> _rules = new List<BusinessRule>();

        // list of validation errors (following validation failure)

        readonly List<string> _errors = new List<string>();

        
        // gets list of validations errors
        [Ignore] 
        public List<string> Errors
        {
            get { return _errors; }
        }

        
        // adds a business rule to the business object
        
        protected void AddRule(BusinessRule rule)
        {
            _rules.Add(rule);
        }

        // determines whether business rules are valid or not.
        // creates a list of validation errors when appropriate
        
        public bool IsValid()
        {
            bool valid = true;

            _errors.Clear();

            foreach (var rule in _rules)
            {
                if (!rule.Validate(this))
                {
                    valid = false;
                    _errors.Add(rule.Error);
                }
            }
            return valid;
        }
    }
}
