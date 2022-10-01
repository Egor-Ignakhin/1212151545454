using UnityEngine;

public class camcontroll : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        /*
        this.transform.position = new Vector3(){
                x=playerTransform.position.x,
                y=playerTransform.position.y,
                z=transform.position.z,
        };
        if(this.playerTransform){
        Vector3 target= new Vector3(){
        x=playerTransform.position.x,
        y=playerTransform.position.y,
        z=transform.position.z,
        };
    */
        var target = new Vector3
        {
            x = playerTransform.position.x,
            y = playerTransform.position.y,
            z = transform.position.z
        };
        var pos = Vector3.Lerp(transform.position, target, moveSpeed * Time.deltaTime);
        transform.position = pos;
    }
}