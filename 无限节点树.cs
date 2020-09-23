using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aa
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TreeVo> treeVo = new List<TreeVo>();
            TreeVo tree = new TreeVo();
            tree.id = 0;
            tree.name = "��˾";
            tree.parentId =-1;
            tree.Children = new List<TreeVo>()
            {
             new TreeVo()
                {
                    id = 8,
                 parentId=0,
                 name="ǰװ��ҵ��"
                },
              new TreeVo()
                {
                 id = 9,
                 parentId=0,
                 name="��װ��ҵ��"
                }
            };
            treeVo.Add(tree);

            tree = new TreeVo();
            tree.id = 1;
            tree.name = "������";
            tree.parentId = 0;
            tree.Children = new List<TreeVo>() {
            new TreeVo (){
            id=10,
            parentId=1,
            name="�Ŵ�"
            }
            };
            treeVo.Add(tree);

            tree = new TreeVo();
            tree.id = 2;
            tree.name = "���ڲ�";
            tree.parentId = 0;
            treeVo.Add(tree);

            tree = new TreeVo();
            tree.id = 3;
            tree.name = "���²�";
            tree.parentId = 0;
            treeVo.Add(tree);

            tree = new TreeVo();
            tree.id = 4;
            tree.name = "����";
            tree.parentId = 1;
            treeVo.Add(tree);

            tree = new TreeVo();
            tree.id = 5;
            tree.name = "���";
            tree.parentId = 2;
            treeVo.Add(tree);

            tree = new TreeVo();
            tree.id = 6;
            tree.name = "��С��";
            tree.parentId = 3;
            treeVo.Add(tree);


            List<TreeVo> t = new List<TreeVo>();
            t= GetTree(treeVo);
            Console.WriteLine(t);
        }

        /// <summary>
        /// ���޲㼶��
        /// </summary>
        /// <param name="treeVo"></param>
        /// <returns></returns>
        public static List<TreeVo>  GetTree(List<TreeVo> treeVo)
        {
            var dicChildren =new  Dictionary<int, TreeVo>(treeVo.Count);
            foreach (var item in treeVo)
            {
                dicChildren.Add(item.id, item);
            }

            foreach (var value in dicChildren.Values)
            {
                if (dicChildren.ContainsKey(value.parentId))
                {
                    if (dicChildren[value.parentId].Children == null) {
                        dicChildren[value.parentId].Children = new List<TreeVo>();
                    }
                        dicChildren[value.parentId].Children.Add(value);
                    
                }
            }
            //t.parentId == -1 ��߲㼶��parentId
            //var result = dicChildren.Values.Where(t => t.parentId == 0).ToList();
            var result = dicChildren.Values.Where(t => t.id == 0).ToList()[0].Children;   
           
            return result; 
        }


    }

   
    public class TreeVo
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentId { get; set; }
        //public object children { get; set; }
        public List<TreeVo> Children { get; set; }
    }





}
