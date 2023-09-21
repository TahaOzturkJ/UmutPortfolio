using Project.BLL.Abstract;
using Project.DAL.Abstract;
using Project.ENTITY.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageManager;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageManager = messageDAL;
        }

        public void TAdd(Message t)
        {
            _messageManager.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messageManager.Delete(t);
        }

        public Message TGetByID(int id)
        {
            return _messageManager.GetByID(id);
        }

        public List<Message> TGetList()
        {
            return _messageManager.GetList();
        }

        public void TUpdate(Message t)
        {
            _messageManager.Update(t);
        }
    }
}
