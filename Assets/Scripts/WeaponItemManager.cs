using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class WeaponItemManager : MonoBehaviour
 {
     private Dictionary<string, ItemWeapon> m_ItemMap = new Dictionary<string, ItemWeapon>();
     public List<ItemWeapon> Items;
     
     private void Awake(){
         foreach (var item in Items){
             m_ItemMap.Add(item.name, item);
         }
     }
     public ItemWeapon Get(string name){
         return m_ItemMap[name];
     }
 }