using Log = Freyja.Logger.Logger;

namespace Freyja.UI
{
    public static class Logger
    {
        private static Log _show;

        public static Log Show
        {
            get
            {
                if (_show == null)
                {
                    _show = Log.AddLog("Freyja UI");
                }

                return _show;
            }
        }
    }
}