using BlazorCrudSampleSsr.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorCrudSampleSsr.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            using (_context)
            {
                try
                {
                    var contact = _context.Contacts.Find(id);
                    _context.Remove(contact);
                    await SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context?.Dispose();
                }
            }
        }

        public async Task DeleteAsync(Contact contact)
        {
            using (_context)
            {
                try
                {
                    if (_context.Entry(contact).State == EntityState.Detached)
                    {
                        _context.Contacts.Attach(contact);
                    }
                    _context.Remove(contact);
                    await SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context?.Dispose();
                }
            }
        }

        public async Task<Contact> FindByIdAsync(int id)
        {
            using (_context)
            {
                try
                {
                    var contact = await _context.Contacts.FindAsync(id);
                    return contact;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context?.Dispose();
                }
            }
        }

        public async Task InsertAsync(Contact contact)
        {
            using (_context)
            {
                try
                {
                    _context.Contacts.Add(contact);
                    await SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context?.Dispose();
                }

            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Contact>> Select()
        {
            using (_context)
            {
                try
                {
                    var contact = await _context.Contacts.ToListAsync();
                    return contact;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context?.Dispose();
                }
            }
        }

        public async Task UpdateAsync(Contact contact)
        {
            using (_context)
            {
                try
                {
                    _context.Contacts.Attach(contact);
                    _context.Entry(contact).State = EntityState.Modified;
                    await SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context?.Dispose();
                }

            }
        }
    }
    
}
