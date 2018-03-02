using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public Transform attackParent;
    private static ArrayList attackDice = new ArrayList();
    private Quaternion attackDiceRot = new Quaternion();
    private float dicePadding = 3.5f;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.A))
        {
            Dice.Roll("1d6", "d6-red", this.transform.position, new Vector3(0f, 0f, 0f));
            Debug.Log("Dice is placed at: " + transform.position);
            
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < Dice.allDice.Count; i++)
            {
                attackDice.Add(Dice.allDice[i]);
                RollingDie newDie;
                newDie = (RollingDie)Dice.allDice[i];
                newDie.gameObject.transform.parent = attackParent;
                newDie.gameObject.transform.localPosition = new Vector3(0f, 0f, (0f + (i * dicePadding)));
                Vector3 newRot = newDie.gameObject.transform.localEulerAngles;
                newRot.y = 90;
                newDie.gameObject.transform.localRotation = Quaternion.Euler(newRot);
                
                
            }

            Debug.Log(attackDice.Count);
        }
	}
}
