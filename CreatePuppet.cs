using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CreatePuppet : MonoBehaviour
{
    public Transform[] bones;
    SkinnedMeshRenderer smr;

    private void Awake()
    {
        Mesh m = new Mesh();

        //bones = new Transform[transform.childCount];
        m.vertices = new Vector3[]
        {
            // 1
            new Vector3(0,4,0),
            new Vector3(-2,0,0),
            new Vector3(2,0,0),

            // 2
            new Vector3(0,0,0),
            new Vector3(-2,-4,0),
            new Vector3(2,-4,0),

            // 3
            new Vector3(0,-4,0),
            new Vector3(-2,-8,0),
            new Vector3(2,-8,0),

            // 4
            new Vector3(-1,-8,0),
            new Vector3(-2,-12,0),
            new Vector3(0,-12,0),

            // 5
            new Vector3(-1,-12,0),
            new Vector3(-2,-16,0),
            new Vector3(0,-16,0),

            // 6
            new Vector3(1,-8,0),
            new Vector3(0,-12,0),
            new Vector3(2,-12,0),

            // 7
            new Vector3(1,-12,0),
            new Vector3(0,-16,0),
            new Vector3(2,-16,0),

            // 8
            new Vector3(-3,0,0),
            new Vector3(-5,-2,0),
            new Vector3(-1,-2,0),

            // 9
            new Vector3(-7,0,0),
            new Vector3(-9,-2,0),
            new Vector3(-5,-2,0),

            // 10
            new Vector3(3,0,0),
            new Vector3(5,-2,0),
            new Vector3(1,-2,0),

            // 11
            new Vector3(7,0,0),
            new Vector3(9,-2,0),
            new Vector3(5,-2,0),

        };
        m.triangles = new int[]
        {
            1,0,2,
            4,3,5,
            7,6,8,
            10,9,11,
            13,12,14,
            16,15,17,
            19,18,20,
            22,21,23,
            25,24,26,
            27,28,29,
            30,31,32

        };
        m.bindposes = new Matrix4x4[]
        {
            bones[0].worldToLocalMatrix*transform.localToWorldMatrix,
            bones[1].worldToLocalMatrix*transform.localToWorldMatrix,
            bones[2].worldToLocalMatrix*transform.localToWorldMatrix,
            bones[3].worldToLocalMatrix*transform.localToWorldMatrix,
            bones[4].worldToLocalMatrix*transform.localToWorldMatrix,
            bones[5].worldToLocalMatrix*transform.localToWorldMatrix,
            bones[6].worldToLocalMatrix*transform.localToWorldMatrix,
            bones[7].worldToLocalMatrix*transform.localToWorldMatrix,
            bones[8].worldToLocalMatrix*transform.localToWorldMatrix,
            bones[9].worldToLocalMatrix*transform.localToWorldMatrix

        };
        m.boneWeights = new BoneWeight[]
        {
            //1
            new BoneWeight(){ boneIndex0=0,weight0=1 },
            new BoneWeight(){ boneIndex0=0,weight0=1 },
            new BoneWeight(){ boneIndex0=0,weight0=1 },
            
            //2
            new BoneWeight(){ boneIndex0=0,weight0=1 },
            new BoneWeight(){ boneIndex0=1,weight0=1 },
            new BoneWeight(){ boneIndex0=1,weight0=1 },
            
            //3
            new BoneWeight(){ boneIndex0=1,weight0=1 },
            new BoneWeight(){ boneIndex0=2,weight0=1 },
            new BoneWeight(){ boneIndex0=3,weight0=1 },
            
            //4
            new BoneWeight(){ boneIndex0=2,weight0=1 },
            new BoneWeight(){ boneIndex0=4,weight0=1 },
            new BoneWeight(){ boneIndex0=4,weight0=1 },
            
            //5
            new BoneWeight(){ boneIndex0=4,weight0=1 },
            new BoneWeight(){ boneIndex0=4,weight0=0 },
            new BoneWeight(){ boneIndex0=4,weight0=0 },
            
            //6
            new BoneWeight(){ boneIndex0=3,weight0=1 },
            new BoneWeight(){ boneIndex0=5,weight0=1 },
            new BoneWeight(){ boneIndex0=5,weight0=1 },
            
            //7
            new BoneWeight(){ boneIndex0=5,weight0=1 },
            new BoneWeight(){ boneIndex0=5,weight0=0 },
            new BoneWeight(){ boneIndex0=5,weight0=0 },
            
            //8
            new BoneWeight(){ boneIndex0=6,weight0=1 },
            new BoneWeight(){ boneIndex0=7,weight0=1 },
            new BoneWeight(){ boneIndex0=6,weight0=1 },
            
            //9
            new BoneWeight(){ boneIndex0=7,weight0=1 },
            new BoneWeight(){ boneIndex0=7,weight0=1 },
            new BoneWeight(){ boneIndex0=7,weight0=1 },
            
            //10
            new BoneWeight(){ boneIndex0=8,weight0=1 },
            new BoneWeight(){ boneIndex0=9,weight0=1 },
            new BoneWeight(){ boneIndex0=8,weight0=1 },
            
            //11
            new BoneWeight(){ boneIndex0=9,weight0=1 },
            new BoneWeight(){ boneIndex0=9,weight0=1 },
            new BoneWeight(){ boneIndex0=9,weight0=1 },
        };
        smr = GetComponent<SkinnedMeshRenderer>();
        smr.bones = bones;
        smr.sharedMesh = m;
        smr.quality = SkinQuality.Bone1;


    }
}
