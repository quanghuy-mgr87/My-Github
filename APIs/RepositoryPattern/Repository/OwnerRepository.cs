using Contracts;
using Entities.Models;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext dbContext) : base(dbContext)
        {
        }

        public Owner CreateOwner(Owner owner)
        {
            Create(owner);
            Save();
            return owner;
        }

        public Owner UpdateOwner(Owner owner)
        {
            Owner currentOwner = dbContext.Owners.FirstOrDefault(x => x.OwnerId == owner.OwnerId);
            if (currentOwner != null)
            {
                currentOwner.Name = owner.Name;
                currentOwner.DateOfBirth = owner.DateOfBirth;
                currentOwner.Address = owner.Address;
                Update(currentOwner);
                Save();
                return currentOwner;
            }
            else
            {
                return null;
            }
        }
    }
}
