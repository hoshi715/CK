using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSteve : MonoBehaviour {

    List<Vector3> Vertices = new List<Vector3>();
    List<Vector2> Uvs = new List<Vector2>();
    int[] triangleint = new int[216];
    private void Awake()
    {
        Mesh m = new Mesh();
        MeshFilter mf = GetComponent<MeshFilter>();

        for (int part = 0; part < 6; part++)
        {
            StiveMesh(retMesh(part), retCenter(part)); // 버텍스
            StiveTrg(part); // 폴리곤
            StiveUV(part);//UV
        }

        m.vertices = Vertices.ToArray();
        m.triangles = triangleint;
        m.uv = Uvs.ToArray();
        
        mf.mesh = m;



    }

    Vector3 retMesh(int _part)
    {
        float[] X = { 4, 4, 2, 2, 2, 2 };
        float[] Y = { 4, 6, 6, 6, 6, 6 };
        float[] Z = { 4, 2, 2, 2, 2, 2 };
        return new Vector3(X[_part], Y[_part], Z[_part]);
    }
    Vector3 retCenter(int _part)
    {
        float[] X = { 0, 0, -6, 6, -2, 2 };
        float[] Y = { 0, -10, -10, -10, -22, -22 };
        return new Vector3(X[_part], Y[_part], 0);
    }
    Vector2 retStartSkinPos(int _part)
    {
        Vector2 temp = new Vector2();
        switch(_part)
        {
            case 0: temp = new Vector2(0, 12); break;
            case 1: temp = new Vector2(4, 8); break;
            case 2: temp = new Vector2(10, 8); break;
            case 3: temp = new Vector2(8, 0); break;
            case 4: temp = new Vector2(0, 8); break;
            case 5: temp = new Vector2(4, 0); break;
        }
        return temp;
    }

    float PosU(int _part, int _dir)
    {
        float[] Ulib = new float[5];
        switch (_part)
        {
            case 0: Ulib = new float[] { 0, 2, 4, 6, 8 }; break;
            case 1: Ulib = new float[] { 0, 1, 3, 5, 6 }; break;
            case 2: Ulib = new float[] { 0, 1, 2, 3, 4 }; break;
            case 3: Ulib = new float[] { 0, 1, 2, 3, 4 }; break;
            case 4: Ulib = new float[] { 0, 1, 2, 3, 4 }; break;
            case 5: Ulib = new float[] { 0, 1, 2, 3, 4 }; break;
        }
        return retStartSkinPos(_part).x + Ulib[_dir];
    }
    float PosV(int _part, int _dir)
    {
        float[] Vlib = new float[3];

        switch (_part)
        {
            case 0: Vlib = new float[] { 0, 2, 4 }; break;
            case 1: Vlib = new float[] { 0, 3, 4 }; break;
            case 2: Vlib = new float[] { 0, 3, 4 }; break;
            case 3: Vlib = new float[] { 0, 3, 4 }; break;
            case 4: Vlib = new float[] { 0, 3, 4 }; break;
            case 5: Vlib = new float[] { 0, 3, 4 }; break;
        }
        return retStartSkinPos(_part).y + Vlib[_dir];
    }
    void StiveMesh(Vector3 _meshXY, Vector3 _center)
    {
        // type1
        Vertices.Add(new Vector3(_center.x - _meshXY.x, _center.y - _meshXY.y, _center.z - _meshXY.z));
        Vertices.Add(new Vector3(_center.x - _meshXY.x, _center.y + _meshXY.y, _center.z - _meshXY.z));
        Vertices.Add(new Vector3(_center.x + _meshXY.x, _center.y + _meshXY.y, _center.z - _meshXY.z));
        Vertices.Add(new Vector3(_center.x + _meshXY.x, _center.y - _meshXY.y, _center.z - _meshXY.z));

        // type2
        Vertices.Add(new Vector3(_center.x - _meshXY.x, _center.y - _meshXY.y, _center.z + _meshXY.z));
        Vertices.Add(new Vector3(_center.x - _meshXY.x, _center.y + _meshXY.y, _center.z + _meshXY.z));
        Vertices.Add(new Vector3(_center.x + _meshXY.x, _center.y + _meshXY.y, _center.z + _meshXY.z));
        Vertices.Add(new Vector3(_center.x + _meshXY.x, _center.y - _meshXY.y, _center.z + _meshXY.z));

        // type2
        Vertices.Add(new Vector3(_center.x - _meshXY.x, _center.y - _meshXY.y, _center.z + _meshXY.z));
        Vertices.Add(new Vector3(_center.x - _meshXY.x, _center.y + _meshXY.y, _center.z + _meshXY.z));
        Vertices.Add(new Vector3(_center.x + _meshXY.x, _center.y + _meshXY.y, _center.z + _meshXY.z));
        Vertices.Add(new Vector3(_center.x + _meshXY.x, _center.y - _meshXY.y, _center.z + _meshXY.z));

        // type1
        Vertices.Add(new Vector3(_center.x - _meshXY.x, _center.y - _meshXY.y, _center.z - _meshXY.z));
        Vertices.Add(new Vector3(_center.x - _meshXY.x, _center.y + _meshXY.y, _center.z - _meshXY.z));
        Vertices.Add(new Vector3(_center.x + _meshXY.x, _center.y + _meshXY.y, _center.z - _meshXY.z));
        Vertices.Add(new Vector3(_center.x + _meshXY.x, _center.y - _meshXY.y, _center.z - _meshXY.z));

        // type2
        Vertices.Add(new Vector3(_center.x - _meshXY.x, _center.y - _meshXY.y, _center.z + _meshXY.z));
        Vertices.Add(new Vector3(_center.x - _meshXY.x, _center.y + _meshXY.y, _center.z + _meshXY.z));
        Vertices.Add(new Vector3(_center.x + _meshXY.x, _center.y + _meshXY.y, _center.z + _meshXY.z));
        Vertices.Add(new Vector3(_center.x + _meshXY.x, _center.y - _meshXY.y, _center.z + _meshXY.z));

    }
    void StiveTrg(int _part)
    {
        int[] trianglesLib =
            {
            // 정면
            0, 1, 2,
            0, 2, 3,

            // 왼쪽
            0, 5, 1,
            0, 4, 5,

            // 오른쪽
            3, 2, 6,
            3, 6, 7,

            // 뒤쪽
            8, 10, 9,
            8, 11, 10,

            // 탑
            13,17,14,
            14,17,18,
            
            // 바텀
            15,16,12,
            15,19,16

        };

        for (int i = 0; i < 36; i++)
        {
            triangleint[_part * 36 + i] = trianglesLib[i] + 20 * _part;
        }
    }
    void StiveUV(int _part)
    {
        //Uvs.Add(new Vector2(Pos(_part,1)*0.0625f, Pos(_part, 1) * 0.0625f));

        // posU*0.0625f;
        Uvs.Add(new Vector2(PosU(_part, 1) * 0.0625f, PosV(_part, 0) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 1) * 0.0625f, PosV(_part, 1) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 2) * 0.0625f, PosV(_part, 1) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 2) * 0.0625f, PosV(_part, 0) * 0.0625f));

        Uvs.Add(new Vector2(PosU(_part, 0) * 0.0625f, PosV(_part, 0) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 0) * 0.0625f, PosV(_part, 1) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 3) * 0.0625f, PosV(_part, 1) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 3) * 0.0625f, PosV(_part, 0) * 0.0625f));

        // 뒤통수
        Uvs.Add(new Vector2(PosU(_part, 4) * 0.0625f, PosV(_part, 0) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 4) * 0.0625f, PosV(_part, 1) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 3) * 0.0625f, PosV(_part, 1) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 3) * 0.0625f, PosV(_part, 0) * 0.0625f));

        // 정수리 턱
        Uvs.Add(new Vector2(PosU(_part, 2) * 0.0625f, PosV(_part, 1) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 1) * 0.0625f, PosV(_part, 1) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 2) * 0.0625f, PosV(_part, 1) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 3) * 0.0625f, PosV(_part, 1) * 0.0625f));

        Uvs.Add(new Vector2(PosU(_part, 2) * 0.0625f, PosV(_part, 2) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 1) * 0.0625f, PosV(_part, 2) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 2) * 0.0625f, PosV(_part, 2) * 0.0625f));
        Uvs.Add(new Vector2(PosU(_part, 3) * 0.0625f, PosV(_part, 2) * 0.0625f));

    }

}
