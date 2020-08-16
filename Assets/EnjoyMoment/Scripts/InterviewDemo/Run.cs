using System.Collections.Generic;
public class Exam {   
    public class MaterialData    {       
        public ItemData item;   //合成所需的物品
               
        public int count;       //合成所需的该物品的数量         
    }

       
    public class ItemData    {       
        public int id;                          //物品 ID
               
        public int count;                       //当前拥有的物品数量
               
        public int costGold;                    //合成该物品所需的金币
               
        public List<MaterialData> materialList; //合成该物品所需的材料
           
    }

       
    /// <summary>
    /// 计算用 totalGold 金币最多可以合成的 item 装备的数量
    /// </summary>
    /// <param name="item">要合成的装备</param>
    /// <param name="totalGold">拥有的金币</param>
    /// <returns>可合成的 item 装备的最大数量</returns>   
    public int Run (ItemData item, int totalGold)    { 

        //求合成一个item需要花费的金币
        int allCostGold = 0;
        allCostGold += item.costGold;
        var mlist = item.materialList;
        while (true) {
            if (mlist.Count != 0) {
                for (int i = 0; i < mlist.Count; i++) {
                    mlist[i].item.costGold += allCostGold;
                    if (mlist[i].item.materialList.Count != 0) {
                        //再遍历一次。只是要改变遍历的对象
                    }
                }

            }

        }
        //如何遍历树
        return 0;   
    }
}