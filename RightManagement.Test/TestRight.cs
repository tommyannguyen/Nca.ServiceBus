using RighManagement.Abtraction;
using RighManagement.Abtraction.HierarchyModels;
using RighManagement.Abtraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RightManagement.Test
{
    
    public class TestRight
    {
        private readonly IRightManager _rightManager;
        private Db _db;
        public TestRight()
        {
            InitialData();
            _rightManager = new RightManager(_db);

        }

        

        [Fact]
        public void Test1()
        {
            var user = _db.Users.FirstOrDefault(u => u.Name == "User 1");
            var role = _db.Roles.FirstOrDefault(r => r.Name == "Admin");
            var rights = _rightManager.GetRelationshipTree(user, role);

        }

        #region Initial database
        private void InitialData()
        {
            var users = new List<User>()
                {
                    new User(){ Id = "User_1", Name = "User 1"},
                    new User(){ Id = "User_2", Name = "User 2"},
                    new User(){ Id = "User_3", Name = "User 3"},
                };

            var roles = new List<Role>()
                {
                    new Role(){ Id = "Role_Admin", Name = "Admin"},
                    new Role(){ Id = "Role_Sale", Name = "Sale"},
                    new Role(){ Id = "Role_Member", Name = "Member"},
                };


            var tenants = new List<Tenant>()
            {

            };


            // Asign user 1
            var relationships = new List<FeatureRelationship>();
            var user1 = users.FirstOrDefault(u => u.Id == "User_1");
            var roleAdmin = roles.FirstOrDefault(r => r.Id == "Role_Admin");

            relationships.Add(new FeatureRelationship() { From = user1, To = roleAdmin , Rights = new List<Right> { Right.Create, Right.Update, Right.Delete} });


            _db = new Db()
            {
                Users = users,
                Roles = roles,
                Tenants = tenants,
                FeatureRelationships = relationships
            };



        }
        #endregion
    }
}
