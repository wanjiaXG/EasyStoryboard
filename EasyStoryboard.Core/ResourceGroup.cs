using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core
{
    public class ResourceGroup
    {
        public string Name { set; get; }

        public bool Visible { private set; get; } = true;

        private ResoureLayerType _storyboardLayerType;
        public ResoureLayerType StoryboardLayerType
        {
            set
            {
                if(_storyboardLayerType!= value)
                {
                    _storyboardLayerType = value;
                    foreach(var item in Resources)
                    {
                        item.ResoureLayerType = value;
                    }
                }
            }
            get
            {
                return _storyboardLayerType;
            }
        }

        public void Show()
        {
            Visible = true;
        }
        
        public void Hide()
        {
            Visible = false;
        }

        public List<Resource> Resources { private set; get; }

        public ResourceGroup()
        {
            Resources = new List<Resource>();
        }

        public ResourceGroup Add(Resource resource)
        {
            Resources.Add(resource.SetStoryboardLayerType(StoryboardLayerType));
            return this;
        }

        public ResourceGroup AddRange(IEnumerable<Resource> resources)
        {
            foreach (var item in resources) Add(item);
            return this;
        } 


    }
}
