﻿/* 
* Copyright (c) Marc Clifton
* The Code Project Open License (CPOL) 1.02
* http://www.codeproject.com/info/cpol10.aspx
*/

using System.Windows.Forms;

using Clifton.Core.ModuleManagement;
using Clifton.Core.Semantics;
using Clifton.Core.ServiceManagement;

using FlowSharpLib;
using FlowSharpServiceInterfaces;

namespace FlowSharpCanvasService
{
    public class FlowSharpCanvasModule : IModule
    {
        public void InitializeServices(IServiceManager serviceManager)
        {
            serviceManager.RegisterSingleton<IFlowSharpCanvasService, FlowSharpCanvasService>();
        }
    }

    public class FlowSharpCanvasService : ServiceBase, IFlowSharpCanvasService
    {
        public BaseController Controller { get { return canvasController; } }
        protected CanvasController canvasController;
        protected Canvas canvas;
        // protected List<GraphicElement> elements;

        public override void Initialize(IServiceManager svcMgr)
        {
            base.Initialize(svcMgr);
            ServiceManager.Get<ISemanticProcessor>().Register<FlowSharpMembrane, FlowSharpCanvasControllerReceptor>();
            canvas = new Canvas();
            canvasController = new CanvasController(canvas);
        }

        public override void FinishedInitialization()
        {
            base.FinishedInitialization();
        }

        public void CreateCanvas(Control parent)
        {
            canvas.Initialize(parent);
        }
    }

    public class FlowSharpCanvasControllerReceptor : IReceptor
    {

    }
}