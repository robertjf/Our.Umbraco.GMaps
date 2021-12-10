﻿#if NET5_0_OR_GREATER
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
#else
using Umbraco.Core;
using Umbraco.Core.Composing;
#endif


namespace Our.Umbraco.GMaps.Core.Composing
{
#if NET5_0_OR_GREATER
    public class Composer : IComposer
#else
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class Composer : IUserComposer
#endif
    {
#if NET5_0_OR_GREATER
        public void Compose(IUmbracoBuilder builder)
        {
            builder.AddNotificationHandler<ServerVariablesParsingNotification, ServerVariablesParsingHandler>();
        }
#else
        public void Compose(Composition composition)
        {
            composition.Components().Append<RegisterServerVariables>();
        }
#endif
    }
}