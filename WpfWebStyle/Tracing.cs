﻿using System.Diagnostics;
using System.Reflection;

namespace WpfWebStyle
{
    public static class Tracing
    {
        public static void Enable()
        {
            Enable(SourceLevels.Warning, null);
        }

        public static void Enable(SourceLevels levels, TraceListener listener)
        {
            if (listener == null)
            {
                listener = new DefaultTraceListener();
            }

            PresentationTraceSources.Refresh();
            foreach (var pi in typeof(PresentationTraceSources).GetProperties(BindingFlags.Static | BindingFlags.Public))
            {
                if (pi.Name == "FreezableSource")
                    continue;

                if (typeof(TraceSource).IsAssignableFrom(pi.PropertyType))
                {
                    var ts = (TraceSource)pi.GetValue(null, null);
                    ts.Listeners.Add(listener);
                    ts.Switch.Level = levels;
                }
            }
        }
    }
}
