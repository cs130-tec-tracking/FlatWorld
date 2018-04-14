using UnityEngine;
using System.Collections;

namespace Stage.App.Models.Environment

{

    public class EnvironmentConfig
    {
        //public eEnvironment environment;
        public EnvironmentApi authApi;
        public EnvironmentApi mainApi;
        public EnvironmentApi api;
        public EnvironmentFacebook facebook;
        public WebUrls webUrls;
        //EnvironmentGoogleAnalytics googleAnalytics;
        //EnvironmentMixpanel mixpanel;
    }

    // public class EnvironmentApi
    // {
    //     public string apiUrl;
    //     public string version;
    //     public string clientId;
    // }

    public class EnvironmentApi {
        public string url;
        public string key;
    }

    public class EnvironmentFacebook
    {
        public string Id;
        public string DisplayName;
    }

    public class WebUrls
    {
        public string root;
        public string forgotPassword;
        public string storeUrl;
    }

    public class EnvironmentGoogleAnalytics
    {
        public string trackingId;
    }

    public class EnvironmentMixpanel
    {
        public string token;
    }
}
