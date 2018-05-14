using HrControl;
using HRManagerDataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagerClient.Utility
{
    public class EntityCollection<T> : ObservableCollection<T> where T : class
    {
        public EntityControl<T> EntityCtrl { get; private set; }
        private readonly Predicate<T> _filter;

        public EntityCollection(EntityControl<T> entityCtrl)
            : this(entityCtrl, null)
        {
        }

        public EntityCollection(EntityControl<T> entityCtrl, Predicate<T> filter)
            : base()
        {
            EntityCtrl = entityCtrl;
            _filter = filter;
            if (_filter == null) {
                _filter = (t) => true;
            }
            RefreshData();
        }

        #region Creating Mode

        public bool IsCreatingMode { get; private set; }
        private T _tInstance;

        public T AddTempNewItem(T newTempItem)
        {
            if (IsCreatingMode || newTempItem == null) return null;
            _tInstance = newTempItem;
            IsCreatingMode = true;
            base.Insert(0, _tInstance);
            return _tInstance;
        }

        public void CreateSubmit()
        {
            if (!IsCreatingMode || _tInstance == null) return;
            EntityCtrl.AddEntity(_tInstance);
            _tInstance = null;
            IsCreatingMode = false;
        }

        #endregion

        public void AddWithEntity(T item)
        {
            if (EntityCtrl.AddEntity(item))
                base.Add(item);
        }

        public bool RemoveWithEntity(T item)
        {
            if (EntityCtrl.DeleteEntity(item))
                return base.Remove(item);
            return false;
        }

        public bool UpdateEntity()
        {
            return EntityCtrl.UpDataEntity();
        }

        public void RefreshData() 
        {
            base.Clear();
            var entities = EntityCtrl.GetEntitys();
            if (entities != null && entities.Count > 0) {
                foreach (var entity in entities) {
                    if (_filter(entity))
                        base.Add(entity);
                }
            }
        }

        public void AddWithoutEntity(T item)
        {
            base.Add(item);
        }

        public EntityCollection<T> Filte(Predicate<T> predicate)
        {
            var result = new EntityCollection<T>(EntityCtrl);
            result.Clear();//新建实例时会把数据全部读进来
            foreach (var item in this) {
                if (predicate(item)) {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
