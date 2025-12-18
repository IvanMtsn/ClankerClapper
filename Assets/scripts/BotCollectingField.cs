using UnityEngine;

public class BotCollectingField : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RecycleBot"))
        {
            //Recycle bot logik
            GameModeManager.Instance.IncreaseScore(30);
            GameModeManager.Instance.AddTime(2);
        }
        if (other.CompareTag("RecycleBotTwo"))
        {
            //Recycle bot 2 logik
            GameModeManager.Instance.IncreaseScore(30);
            GameModeManager.Instance.AddTime(2);
        }
        if (other.CompareTag("DamagedBot"))
        {
            //Damaged bot logik
            GameModeManager.Instance.DecreaseScore(10);
        }
        if (other.CompareTag("DefectBot"))
        {
            //Defect bot logik
            GameModeManager.Instance.DecreaseScore(15);
        }
        other.gameObject.GetComponent<EnemyDroid>().enabled = false;
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        Destroy(other.gameObject, 1.5f);
    }
}