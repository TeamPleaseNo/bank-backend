﻿using Database.Interfaces;
using Database.Models;

namespace Database.Repository
{
    public class OrganisationsRepository : IOrganisationsRepository
    {
        private readonly ApplicationContext _context;

        public OrganisationsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(Organisation item)
        {
            _context.Organisations.Add(item);
            return true;
        }

        public bool Delete(int id)
        {
            var org = GetItem(id);
            if (org == default)
                return false;

            _context.Organisations.Remove(org);
            return true;
        }

        public IEnumerable<Organisation> GetAll()
        {
            return _context.Organisations;
        }

        public Organisation? GetItem(int id)
        {
            return _context.Organisations.FirstOrDefault(a => a.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(Organisation item)
        {
            _context.Organisations.Update(item);
            return true;
        }
    }
}
