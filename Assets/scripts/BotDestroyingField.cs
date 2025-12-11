using UnityEngine;

public class BotDestroyingField : MonoBehaviour
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
        }
        if (other.CompareTag("RecycleBotTwo"))
        {
            //Recycle bot 2 logik
        }
        if (other.CompareTag("DamagedBot"))
        {
            //Damaged bot logik
        }
        if (other.CompareTag("DefectBot"))
        {
            //Defect bot logik
        }
        other.gameObject.GetComponent<EnemyDroid>().enabled = false;
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        Destroy(other.gameObject, 1.5f);
    }
}