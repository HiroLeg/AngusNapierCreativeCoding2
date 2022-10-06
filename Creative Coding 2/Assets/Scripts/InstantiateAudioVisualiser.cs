using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAudioVisualiser : MonoBehaviour
{
    public GameObject sampleCirclePrefab;
   GameObject[] _CirclePrefab = new GameObject[512];
    public float maxHeight;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject _instanceCircle = (GameObject)Instantiate(sampleCirclePrefab);
            _instanceCircle.transform.position = this.transform.position;
            _instanceCircle.transform.parent = this.transform;
            _instanceCircle.name = "SampleCircle" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            _instanceCircle.transform.position = Vector3.forward * 100;
            _CirclePrefab[i] = _instanceCircle;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if(_CirclePrefab != null)
            {
                _CirclePrefab[i].transform.localPosition = new Vector3(_CirclePrefab[i].transform.localPosition.x, (AudioVisualizer._samples[i] * maxHeight) + 2, _CirclePrefab[i].transform.localPosition.z);
            }
        }
    }
}
