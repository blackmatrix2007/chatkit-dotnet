using System;
using System.Collections.Generic;

namespace t.JibPush
{
    public class PPHTTPEndpointTokenProviderRequest
    {
        Dictionary<String, String> headers = new Dictionary<string, string>();

        public PPHTTPEndpointTokenProviderRequest()
        {
        }
    }
}


//public class PPHTTPEndpointTokenProviderRequest
//{
//    public var headers: [String: String] = [:]
//    public var body: PPHTTPBody? = []
//    public var queryItems: [URLQueryItem] = []

//    // If a header key already exists then calling this will override it
//    public func addHeaders(_ newHeaders: [String: String])
//    {
//        for header in newHeaders {
//            self.headers[header.key] = header.value
//        }
//    }

//    public func addQueryItems(_ newQueryItems: [URLQueryItem])
//    {
//        self.queryItems.append(contentsOf: newQueryItems)
//    }
//}