using Luna.Models;
using System;
using Luna.IDAL;

namespace Luna.DAL
{
    public class UserRepository:BaseRepository<User>,InterfaceUserRepository
    {
    }
}
