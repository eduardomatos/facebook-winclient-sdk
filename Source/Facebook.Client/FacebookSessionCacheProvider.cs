﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Client
{
    public abstract class FacebookSessionCacheProvider
    {

        private static FacebookSessionCacheProvider current;

        public static FacebookSessionCacheProvider Current
        {
            get
            {
                if (current == null)
                {
#if WINDOWS_PHONE
                    current = new FacebookSessionIsolatedStorageCacheProvider();
#else
                    current = new FacebookSessionLocalSettingsCacheProvider();
#endif
                }
                return current;
            }
        }

        public static void SetCacheProvider(FacebookSessionCacheProvider provider)
        {
            current = provider;
        }

        public abstract FacebookSession GetSessionDataAsync();

        public abstract void SaveSessionDataAsync(FacebookSession data);

        public abstract void DeleteSessionDataAsync();

    }
}
