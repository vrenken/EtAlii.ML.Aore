namespace EtAlii.ML.Aore.Service
{
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public partial class SystemContext : SystemContextBase
    {
        private IHost _host;
        private ILogger _logger;

        public SystemContext()
        {
        }

        protected override void OnAddingAspectEntered() {}

        protected override void OnAddingAspectExited() {}

        protected override void OnAddingAspectEnteredFromAddAspectTrigger() {}

        protected override void OnAddingConceptEntered() {}

        protected override void OnAddingConceptExited() {}

        protected override void OnAddingConceptEnteredFromAddConceptTrigger() {}

        protected override void OnAddingImagesToProjectEntered() {}

        protected override void OnAddingImagesToProjectExited() {}

        protected override void OnAddingImagesToProjectEnteredFromAddImagesToProjectTrigger() {}

        protected override void OnAddingProjectEntered() {}

        protected override void OnAddingProjectExited() {}

        protected override void OnAddingProjectEnteredFromAddProjectTrigger() {}

        protected override void OnIdleEntered() {}

        protected override void OnIdleExited() {}

        protected override void OnManagingConceptsEntered() {}

        protected override void OnRemovingConceptEntered() {}

        protected override void OnRemovingConceptExited() {}

        protected override void OnIdleEnteredFromReadyTrigger() {}

        protected override void OnIdleEnteredFromStartingToIdleTrigger() {}
    }
}
