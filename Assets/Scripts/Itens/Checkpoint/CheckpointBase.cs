using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBase : MonoBehaviour
{
    public AudioSource sfx;
    public MeshRenderer meshRenderer;
    public int key = 01;
    private string checkpointKey = "CheckPointKey";
 [SerializeField]   private bool checkPointActivated=false;

    public void Awake()
    {
        TurnitOff();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!checkPointActivated &&  other.transform.tag=="Player")
        {
        CheckCheckpoint();

        }
    }
    private void CheckCheckpoint()
    {
        TurnitOn();
        SaveCheckpoint();
    }
    [NaughtyAttributes.Button]
    private void TurnitOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.grey);
    }
    [NaughtyAttributes.Button]

    private void TurnitOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
        if(sfx != null) sfx.Play();
    }
    private void SaveCheckpoint()
    {
      //  if (PlayerPrefs.GetInt(checkpointKey, 0) >key )
       // PlayerPrefs.SetInt(checkpointKey, key);
        checkPointActivated=true;
        CheckPointManager.Instance.SaveCheckPoint(key);

    }
}
