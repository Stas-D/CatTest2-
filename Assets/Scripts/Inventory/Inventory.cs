using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public bool [] isFull;
    public GameObject [] slots;
    [SerializeField]
    private GameObject Slot;
    [SerializeField]
    private GameObject Slot2;
    private Transform player;
    private GameObject inventory;
   

 private void Start() {
   
     inventory = GameObject.FindGameObjectWithTag("Inventory");
     slots[0]= inventory.transform.GetChild(0).gameObject; 
     slots[1]= inventory.transform.GetChild(1).gameObject;
     Slot = inventory.transform.GetChild(0).gameObject; 
     Slot2 = inventory.transform.GetChild(1).gameObject;
     
    
}
  

public bool HasFullSlots() {
        for (int i = 0; i < slots.Length; i++) {
            if (isFull[i]) {
                return true;    
            }
        }
        return false;
    }


public void removeFromArray() {



for (int i = 0; i <1; i++) {
                
                    if (isFull[1]) {
                   GameObject mySlotChild2 = Slot2.transform.GetChild(0).gameObject;     
                Debug.Log("Дичь" + Slot2.transform.childCount);
                Destroy (mySlotChild2);
                isFull[1] = false;

                 }
                 else if (isFull[0])            
                  {
                      GameObject mySlotChild = Slot.transform.GetChild(0).gameObject;
                    Debug.Log("Дичь" + Slot.transform.childCount);
                   Destroy (mySlotChild);
                   isFull[0] = false;
                    
                   } 
                else
                {
                    Debug.Log("Дииииииииииичь");
                }
                   
}
                }

                // Debug.Log("slots[i] = null");
                // Debug.Log("Дичь" + Slot.transform.childCount);
               // inventory.slots[i].transform
               // Slot [] slots1 = GetComponents<Slot>();
               // slots1[i].DropItem();
              
            }
        
    




/*

Чтобы получить список "детей" данного объекта, можно использовать такой подход:

foreach(Transform child in transform) {
    // итерируемся по всем детям
    // для получения именно объекта ребенка - используем child.gameObject
}

Чтобы выключить/включить всех детей, проще написать метод, используя код выше:

void SetChildrenActiveState(bool active) {
    foreach(Transform child in transform) {
        child.gameObject.SetActive(active);
    }
}

Также надо понимать, что условие if (transform.position.y < -20) будет каждый кадр возвращать true 
после преодоления объектом высоты в -20f. Поэтому желательно завести какой-нибудь флаг, если же таких "состояний" 
больше 2, то лучше завести конечный автомат, но это уже совсем другая история.




Поменять родителя у трансформа можно с помощью вызова Transform.SetParent либо прямой замены Transform.parent. 
Кроме того, в последних версиях юнити появилась новая версия Instantiate, которая позволяет указать 
родителя при создании объекта.

using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform prefab;
    public Transform parent;

    private void Start()
    {
        // Создаём новый объект из префаба
        var child = Instantiate(prefab);
        // Присваиваем родителя
        child.SetParent(parent);
        // Либо так
        child.parent = parent;

        // Либо сразу в одну строчку
        var child = Instantiate(prefab, parent);
    }
}





    public void removeFromArray(GameObject slot) {
        for (int i = 1; i < slots.Length; i--)  {
            if (slots[i].GetInstanceID() == slot.GetInstanceID()) {
               isFull[i] == false;
            }
        }
    }


/*
    List<GameObject> list  = new ArrayList<>();
    
    public void add(GameObject slot) {
        list.Add(slot);
    }

    public void remove(GameObject slot) {
        list.Remove(slot);
    }

    public void removeFromArray(GameObject slot) {
        for (int i = 0; i < slots.Length; i++)  {
            if (slots[i].GetInstanceID() == slot.GetInstanceID()) {
                slots[i] == null;
            }
        }
    }

    public void addToArray(GameObject slot) {
        for(int i = 0; i < slots.Length; i++) {
            if (slots[i] == null) {
                slots[i] = slot;
            }
        }
    }

    public bool HasFullSlots() {
        for (int i = 0; i < slots.Length; i++) {
            if (isFull[i]) {
                return true;    
            }
        }
        return false;
    }
*/
