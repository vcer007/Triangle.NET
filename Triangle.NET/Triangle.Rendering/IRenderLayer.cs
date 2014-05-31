﻿
namespace TriangleNet.Rendering
{
    using System.Drawing;
    using TriangleNet.Geometry;
    using TriangleNet.Meshing;
    using TriangleNet.Rendering.Buffer;
    using TriangleNet.Rendering.Util;
    using TriangleNet.Tools;

    public interface IRenderLayer
    {
        int Count { get; }

        // Points can be set, because layers may share vertices.
        IBuffer<float> Points { get; }
        IBuffer<int> Indices { get; }

        bool IsActive { get; set; }
        bool IsEmpty { get; }

        void Reset(bool clear);

        // TODO: add boolean: reset
        BoundingBox SetPoints(IBuffer<float> buffer);
        BoundingBox SetPoints(IPolygon poly);
        BoundingBox SetPoints(IMesh mesh);
        BoundingBox SetPoints(IVoronoi voronoi);
        void SetPolygon(IPolygon poly);
        void SetPolygon(IMesh mesh);
        void SetMesh(IMesh mesh, bool elements);
        void SetMesh(IVoronoi voronoi);


        // TODO: better put these into a subclass.
        IBuffer<int> Partition { get; }
        IBuffer<Color> Colors { get; }

        void AttachLayerData(float[] values, ColorMap colormap);
        void AttachLayerData(int[] partition);
    }
}
