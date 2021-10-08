using System;
using System.Text;

namespace HraveMzdy.Legalios.Service.Errors
{
    class HistoryResultError : IHistoryResultError
    {
        public static HistoryResultError CreateBundleNoneError()
        {
            return new HistoryResultError(null, "service hasn't returned bundle");
        }
        public static HistoryResultError CreateBundleNullError()
        {
            return new HistoryResultError(null, "service returned null bundle");
        }
        public static HistoryResultError CreateBundleEmptyError()
        {
            return new HistoryResultError(null, "service returned empty bundle");
        }
        public static HistoryResultError CreateBundleInvalidError()
        {
            return new HistoryResultError(null, "service returned invalid bundle");
        }
        protected static HistoryResultError CreateError(string errorText)
        {
            return new HistoryResultError(null, errorText);
        }
        protected HistoryResultError(IHistoryResultError inner, string errorText)
        {
            InnerResult = inner;

            Error = string.Format("{0} for {1}", "ResultError", errorText);
        }
        public string Description()
        {
            StringBuilder errorBuilder = new StringBuilder(Error);
            if (InnerResult != null)
            {
                errorBuilder.AppendLine("Inner error:");
                errorBuilder.Append(InnerResult.Description());
            }
            return errorBuilder.ToString();
        }
        public IHistoryResultError InnerResult { get; protected set; }
        public string Error { get; protected set; }
    }

}
