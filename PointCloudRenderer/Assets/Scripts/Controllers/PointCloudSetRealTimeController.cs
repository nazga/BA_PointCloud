﻿using CloudData;
using Loading;
using ObjectCreation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Controllers {

    /* This PointSetController updates the loading queue every frame, so at every frame the nodes which should be loaded are adapted to the current camera position.
     */
    public class PointCloudSetRealTimeController : AbstractPointSetController {
        
        public uint pointBudget;
        public int minNodeSize;
        public uint nodesLoadedPerFrame = 35;
        public uint nodesGOsPerFrame = 30;
        //Defines the type of PointCloud (Points, Quads, Circles)
        public MeshConfiguration meshConfiguration;
        public uint cacheSizeInPoints = 0;

        private Camera userCamera;

        // Use this for initialization
        protected override void Initialize() {
            userCamera = Camera.main;
            PointRenderer = new V2Renderer(minNodeSize, pointBudget, nodesLoadedPerFrame, nodesGOsPerFrame, userCamera, meshConfiguration, cacheSizeInPoints);
        }
        

        // Update is called once per frame
        void Update() {
            if (!CheckReady()) return;
            PointRenderer.Update();
        }
    }
}