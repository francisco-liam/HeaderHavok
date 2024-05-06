using UnityEngine.UI; // Don't forget this line
public class Script : MonoBehaviour
{
   public Text scoreText;
   public float counter;
    public Text liveText;
 
   public void Update()
   {
        scoreText.text =  "Score: " + counter.ToString();
        liveText.text =  "Lives: " + counter.ToString();
        counter++;
   }
}
