using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightFactory : MonoBehaviour
{
   FightContext fightContext;
   public FightFactory(){}

   public void Inject(FightContext fightContext){
    this.fightContext = fightContext;
   }

   
}
