using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;
using YVR.Utilities;

namespace YVR.Core
{
    public class YVRPlaneDetectorMgr : Singleton<YVRPlaneDetectorMgr>
    {
        public static Action<List<YVRPlaneDetectorLocation>> getPlanesAction;

        protected override void OnInit()
        {
            base.OnInit();
            YVRPlugin.Instance.SetPlaneDetectionsCallback(OnPlaneDetectorInfoAction);
        }

        [MonoPInvokeCallback(typeof(Action<YVRPlaneDetectorLocationsInternal>))]
        private static void OnPlaneDetectorInfoAction(YVRPlaneDetectorLocationsInternal planeDetectorLocations)
        {
            List<YVRPlaneDetectorLocation> planes = new List<YVRPlaneDetectorLocation>();
            if (planeDetectorLocations.planeLocationCountOutput > 0 &&
                planeDetectorLocations.planeLocations != IntPtr.Zero)
            {
                List<YVRPlaneDetectorLocationInternal> planeDetectorInternals =
                    ConvertIntPtr2List<YVRPlaneDetectorLocationInternal>(planeDetectorLocations.planeLocations,
                        planeDetectorLocations.planeLocationCountOutput);
                foreach (var item in planeDetectorInternals)
                {
                    YVRPlaneDetectorLocation plane = new YVRPlaneDetectorLocation();
                    plane.planeId = item.planeId;
                    plane.locationFlags = item.locationFlags;
                    plane.pose = item.pose;
                    plane.extents = item.extents;
                    plane.orientation = item.orientation;
                    plane.semanticType = item.semanticType;
                    plane.changeState = item.changeState;
                    plane.polygonBufferCount = item.polygonBufferCount;
                    planes.Add(plane);
                }
            }

            getPlanesAction?.Invoke(planes);
        }

        /// <summary>
        /// Creates plane detection.
        /// </summary>
        public void CreatePlaneDetector()
        {
            YVRPlugin.Instance.CreatePlaneDetection();
        }

        public List<YVRPlaneDetectorPolygonBuffer> GetPlanePolygonBuffer(YVRPlaneDetectorLocation plane)
        {
            List<YVRPlaneDetectorPolygonBuffer> polygons = new List<YVRPlaneDetectorPolygonBuffer>();
            IntPtr polygonBuffersIntPtr =
                YVRPlugin.Instance.GetPolygonBuffer(plane.planeId, plane.polygonBufferCount);
            YVRPlaneDetectorPolygonBuffersInternal polygonBuffersInternal =
                Marshal.PtrToStructure<YVRPlaneDetectorPolygonBuffersInternal>(polygonBuffersIntPtr);
            if (polygonBuffersInternal.bufferCount > 0 && polygonBuffersInternal.buffers != IntPtr.Zero)
            {
                List<YVRPlaneDetectorPolygonBufferInternal> polygonBuffers =
                    ConvertIntPtr2List<YVRPlaneDetectorPolygonBufferInternal>(polygonBuffersInternal.buffers,
                        polygonBuffersInternal.bufferCount);

                foreach (var buffer in polygonBuffers)
                {
                    List<Vector2> pointVectors = ConvertIntPtr2List<Vector2>(buffer.vertices, buffer.vertexCountOutput);
                    YVRPlaneDetectorPolygonBuffer polygon = new YVRPlaneDetectorPolygonBuffer();
                    polygon.pointVectors = pointVectors;
                    polygons.Add(polygon);
                }
            }

            return polygons;
        }

        /// <summary>
        /// Ends plane detection.
        /// </summary>
        public void EndPlaneDetector()
        {
            YVRPlugin.Instance.EndPlaneDetection();
        }

        public static List<T> ConvertIntPtr2List<T>(IntPtr ptr, uint count)
        {
            List<T> objArray = new List<T>();
            for (int i = 0; i < count; i++)
            {
                IntPtr objPtr = IntPtr.Add(ptr, i * Marshal.SizeOf<T>());
                objArray.Add(Marshal.PtrToStructure<T>(objPtr));
            }

            return objArray;
        }
    }
}