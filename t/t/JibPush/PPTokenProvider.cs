using System;

namespace t.JibPush
{
    public interface PPTokenProvider
    {
        void fetchToken(Action<PPTokenProviderResult,String> action);
    }
}

