using System.Collections.Generic;
using System.Linq;

namespace SmartAdLibrary.Utils
{
    public class BusinessCheckOrchestrator<TContext> : IBusinessCheck<TContext>
    {
        private readonly IList<IBusinessCheck<TContext>> _checks;

        public BusinessCheckOrchestrator(params IBusinessCheck<TContext>[] businessChecks)
        {
            _checks = businessChecks.ToList();
        }

        public void Execute(TContext context)
        {
            var exceptions = new List<BusinessException>();

            foreach (var check in _checks)
            {
                try
                {
                    check.Execute(context);
                }
                catch (BusinessException e)
                {
                    exceptions.Add(e);
                }
            }

            if (exceptions.Count > 0)
            {
                throw new BusinessException(
                    string.Join(", ", exceptions.Select(e => e.Message)));
            }
        }
    }
}
