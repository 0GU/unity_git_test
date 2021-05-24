using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class TagCheck : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject[] Greentag_Objects; //代入用のゲームオブジェクト配列を用意
    GameObject[] Bluetag_Objects; //代入用のゲームオブジェクト配列を用意
    GameObject[] Yellowtag_Objects; //代入用のゲームオブジェクト配列を用意

    GameObject[] Green_Objects; //代入用のゲームオブジェクト配列を用意
    GameObject[] Blue_Objects; //代入用のゲームオブジェクト配列を用意
    GameObject[] Yellow_Objects; //代入用のゲームオブジェクト配列を用意

    [SerializeField] public GameObject Green;
    [SerializeField] public GameObject Blue;
    [SerializeField] public GameObject Yellow;

    Vector3 Green_trans;
    Vector3 Blue_trans;
    Vector3 Yellow_trans;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Greentag_Objects = GameObject.FindGameObjectsWithTag("Green Panel");
        Bluetag_Objects = GameObject.FindGameObjectsWithTag("Blue Panel");
        Yellowtag_Objects = GameObject.FindGameObjectsWithTag("Yellow Panel");

        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int g = 0; g < Greentag_Objects.Length; g++)
            {
                Green_trans = Greentag_Objects[g].transform.position;

                switch (Greentag_Objects[g].name)
                {
                    case "Quad1":
                        Instantiate(Green, new Vector3(Green_trans.x, Green_trans.y, Green_trans.z-0.5f), Quaternion.identity);
                        break;
                    case "Quad2":
                        Instantiate(Green, new Vector3(Green_trans.x, Green_trans.y + 0.5f, Green_trans.z), Quaternion.identity);
                        break;
                    case "Quad3":
                        Instantiate(Green, new Vector3(Green_trans.x - 0.5f, Green_trans.y, Green_trans.z), Quaternion.identity);
                        break;
                    case "Quad4":
                        Instantiate(Green, new Vector3(Green_trans.x + 0.5f, Green_trans.y, Green_trans.z), Quaternion.identity);
                        break;
                    case "Quad5":
                        Instantiate(Green, new Vector3(Green_trans.x, Green_trans.y, Green_trans.z + 0.5f), Quaternion.identity);
                        break;
                    case "Quad6":
                        Instantiate(Green, new Vector3(Green_trans.x, Green_trans.y - 0.5f, Green_trans.z), Quaternion.identity);
                        break;
                   }
            }

            for (int b = 0; b < Bluetag_Objects.Length; b++)
            {
                Blue_trans = Bluetag_Objects[b].transform.position;
                switch (Bluetag_Objects[b].name)
                {
                    case "Quad1":
                        Instantiate(Blue, new Vector3(Blue_trans.x, Blue_trans.y, Blue_trans.z - 0.5f), Quaternion.identity);
                        break;
                    case "Quad2":
                        Instantiate(Blue, new Vector3(Blue_trans.x, Blue_trans.y + 0.5f, Blue_trans.z), Quaternion.identity);
                        break;
                    case "Quad3":
                        Instantiate(Blue, new Vector3(Blue_trans.x - 0.5f, Blue_trans.y, Blue_trans.z), Quaternion.identity);
                        break;
                    case "Quad4":
                        Instantiate(Blue, new Vector3(Blue_trans.x + 0.5f, Blue_trans.y, Blue_trans.z), Quaternion.identity);
                        break;
                    case "Quad5":
                        Instantiate(Blue, new Vector3(Blue_trans.x, Blue_trans.y, Blue_trans.z + 0.5f), Quaternion.identity);
                        break;
                    case "Quad6":
                        Instantiate(Blue, new Vector3(Blue_trans.x, Blue_trans.y - 0.5f, Blue_trans.z), Quaternion.identity);
                        break;
                }
            }

            for (int y = 0; y < Yellowtag_Objects.Length; y++)
            {
                Yellow_trans = Yellowtag_Objects[y].transform.position;
                switch (Yellowtag_Objects[y].name)
                {
                    case "Quad1":
                        Instantiate(Yellow, new Vector3(Yellow_trans.x, Yellow_trans.y, Yellow_trans.z - 0.5f), Quaternion.identity);
                        break;
                    case "Quad2":
                        Instantiate(Yellow, new Vector3(Yellow_trans.x, Yellow_trans.y + 0.5f, Yellow_trans.z), Quaternion.identity);
                        break;
                    case "Quad3":
                        Instantiate(Yellow, new Vector3(Yellow_trans.x - 0.5f, Yellow_trans.y, Yellow_trans.z), Quaternion.identity);
                        break;
                    case "Quad4":
                        Instantiate(Yellow, new Vector3(Yellow_trans.x + 0.5f, Yellow_trans.y, Yellow_trans.z), Quaternion.identity);
                        break;
                    case "Quad5":
                        Instantiate(Yellow, new Vector3(Yellow_trans.x, Yellow_trans.y, Yellow_trans.z + 0.5f), Quaternion.identity);
                        break;
                    case "Quad6":
                        Instantiate(Yellow, new Vector3(Yellow_trans.x, Yellow_trans.y - 0.5f, Yellow_trans.z), Quaternion.identity);
                        break;
                }
            }
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            Blue_Objects = GameObject.FindGameObjectsWithTag("Blue");
            Green_Objects = GameObject.FindGameObjectsWithTag("Green");
            Yellow_Objects = GameObject.FindGameObjectsWithTag("Yellow");
            for (int i = 0; i < Blue_Objects.Length; i++)
            {
                Destroy(Blue_Objects[i]);
            }
            for (int i = 0; i < Green_Objects.Length; i++)
            {
                Destroy(Green_Objects[i]);
            }
            for (int i = 0; i < Yellow_Objects.Length; i++)
            {
                Destroy(Yellow_Objects[i]);
            }
        }
    }
}
