using UnityEngine;
using System.Collections;

public class RespondScript : MonoBehaviour {
    public UnityEngine.UI.InputField inputField;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //print("test: " + textThing.text);
        if(inputField.isFocused && Input.GetButtonDown("Submit"))
        {
            string[] parameters = inputField.text.Split(' ');
            parameters[parameters.GetLength(0) - 1] = 
                parameters[parameters.GetLength(0) - 1].
                    Remove(parameters[parameters.GetLength(0) - 1].Length-1);
            if (parameters[0].Equals("clear"))
            {
                Camera.main.GetComponent<spawner>().deleteAll();
            }

            if (parameters.GetLength(0) > 1)
            {
                if (parameters[0].Equals("s"))
                {
                    if(parameters[1].Equals("rand"))
                    {
                        Camera.main.GetComponent<spawner>().spawnBunch();
                    }

                    if(parameters.GetLength(0) > 2)
                    {
                        int num = 1;
                        if (parameters.GetLength(0) == 4)
                            num = int.Parse(parameters[3]);
                        ShipDefinitions.Faction faction = ShipDefinitions.Faction.Indep;
                        if (parameters[1].Equals("g"))
                            faction = ShipDefinitions.Faction.PlayerAffil;
                        else if(parameters[1].Equals("r"))
                            faction = ShipDefinitions.Faction.Enemy;

                        for (int i = 0; i <= num; i++)
                        {
                            Vector2 randPt = Bounds.getRandPosInBounds();
                            switch (parameters[2])
                            {
                                case "f":
                                    Camera.main.GetComponent<spawner>().spawnFireShip(faction, randPt);
                                    break;
                                case "l":
                                    Camera.main.GetComponent<spawner>().spawnCrownShip(faction, randPt);
                                    break;
                                case "m":
                                    Camera.main.GetComponent<spawner>().spawnMissileShip(faction, randPt);
                                    break;
                            }
                        }
                    }
                }
                else if (parameters[0].Equals("n"))
                {
                    foreach (ImplMainShip ship in GameObject.FindObjectsOfType<ImplMainShip>())
                    {
                        print(ship.getName().Substring(ship.getName().Length - 4));
                        if (ship.getName().Equals(parameters[1]) ||
                            ship.getName().Substring(ship.getName().Length - 4).Equals(parameters[1]))
                        {
                            Camera.main.GetComponent<Pause>()
                                .requestManualControl(ship.gameObject);
                            break;
                        }
                    }
                }
            }
            inputField.text = "";
        }

        if(Input.GetButtonDown("Submit"))
        {
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
        }

    }
}
