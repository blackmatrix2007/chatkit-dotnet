using System;
namespace t.JibPush
{
    public class PPHTTPEndpointTokenProvider : PPTokenProvider
    {
        //    public var url: String

        //// TODO: Seems like there is a better name for this

        //public var requestInjector: ((PPHTTPEndpointTokenProviderRequest) -> (PPHTTPEndpointTokenProviderRequest))?
        //public var accessToken: String? = nil
        //public internal (set) var accessTokenExpiresAt: Double? = nil
        //public var retryStrategy: PPRetryStrategy
        //public var logger: PPLogger? = nil {
        //    willSet {
        //        (self.retryStrategy as? PPDefaultRetryStrategy)?.logger = newValue
        //    }
        //}
        String url;
        Action<PPHTTPEndpointTokenProviderRequest> requestInjector;

        public PPHTTPEndpointTokenProvider()
        {

        }

        public void fetchToken(Action<PPTokenProviderResult, string> action)
        {

        }
    }
}
