using System.Collections.Generic;

namespace Flight_Planner.Services.Validator
{
    public class ValidationResponse
    {
        public ValidationResponse(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public bool Succeeded { get; private set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();

        public ValidationResponse Set(IEnumerable<string> errors)
        {
            Errors = errors;
            return this;
        }
    }
}