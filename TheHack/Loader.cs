using System;
using CodeStage.AntiCheat.Detectors;
using Il2CppSystem;
using MelonLoader;
using UnityEngine;

namespace TheHack
{
    public class Loader : MelonMod

    {

        public static void Start()
        {
            /*Color textColor = GUI.skin.label.normal.textColor;
            GUI.skin.label.normal.textColor = Color.black;
            int fontSize = GUI.skin.label.fontSize;
            GUI.skin.label.fontSize = 22;
            GUI.Label(new Rect(100, 100, 300, 100), "TEST");
            GUI.skin.label.fontSize = fontSize;
            GUI.skin.label.normal.textColor = textColor;*/
            InjectionDetector.Dispose();
            ObscuredCheatingDetector.Dispose();
            SpeedHackDetector.Dispose();
            TimeCheatingDetector.Dispose();
            WallHackDetector.Dispose();

        }
        public override void OnGUI()
        {

            //pretty background :)
            GUI.Box(new Rect(20, 20, 500, 100), "Made by Yeemodz and V4NIT");

            GUI.Label(new Rect(30, 35, 200, 100), "- " + "GIVE WEAPONS ( KEY X)");
            GUI.Label(new Rect(30, 55, 200, 100), "- " + "PUSH UP (KEY F)");
            GUI.Label(new Rect(30, 75, 200, 100), "- " + "TELEPORT (KEY T)");


            GUI.Label(new Rect(30, 100, 200, 100), "- " + "Antishit has also been turned off");
            //buttons (which do things)

        }

        public override void OnUpdate()
        {



            bool teleport = Input.GetKeyDown(KeyCode.T);

            if (teleport)
            {
                //PlayerStatus.Instance.gameObject.transform.position = new Vector3(0f, 0f, 0f);

                Ray ray = new Ray(PlayerMovement.Instance.transform.position, Camera.main.transform.forward);
                RaycastHit raycastHit;
                Physics.Raycast(ray, out raycastHit);
                PlayerMovement.Instance.transform.position = raycastHit.point + new Vector3(0f, 2f, 0f);
            }
            bool god = Input.GetKeyDown(KeyCode.E);
            if (god)
            {
                PlayerMovement.Instance.punchPlayers.punchCooldown = 0.0f;
                PlayerMovement.Instance.punchPlayers.Punch();
                PlayerMovement.Instance.punchPlayers.punchCooldown = 1.0f;
            }
            bool flagger = Input.GetKeyDown(KeyCode.X);
            if (flagger)
            {
                PlayerInventory.Instance.ForceGiveItem(ItemManager.GetItemById(6));
                PlayerInventory.Instance.ForceGiveItem(ItemManager.GetItemById(1));

                // PlayerInventory.Instance.GetAmmoOfType(ItemAmmo.AmmoType.Shotgun);
                PlayerInventory.Instance.ForceGiveItem(ItemManager.GetItemById(4));


            }
            bool flag = PlayerMovement.Instance != null;
            if (flag)
            {


                bool keyDown = Input.GetKeyDown(KeyCode.F);

                if (keyDown)
                {
                    PlayerMovement.Instance.underWater = true;
                    PlayerMovement.Instance.iceMultiplier = 0;
                    PlayerMovement.Instance.iceMoveSpeed = 1;
                    PlayerMovement.Instance.swimSpeed = 20000f;

                }
                bool keyUp = Input.GetKeyUp(KeyCode.F);
                if (keyUp)
                {
                    PlayerMovement.Instance.underWater = false;
                }


                //  MelonLogger.Msg(PlayerMovement.Instance.dead);
                PlayerStatus.Instance.currentHp = 999999999;
                PlayerStatus.Instance.maxHp = 999999999;
                PlayerMovement.Instance.maxBreakFallAngle = 1;
                PlayerMovement.Instance.fallSpeed = 0;
                PlayerMovement.Instance.dead = false;
                PlayerMovement.Instance.punchPlayers.punchCooldown = 0.0f;
                PlayerMovement.Instance.grounded = true;
                // Start();
            }
            Start();
        }

    }

}