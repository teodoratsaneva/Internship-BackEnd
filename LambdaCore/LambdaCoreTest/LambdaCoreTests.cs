using NUnit.Framework;
using System;

namespace LambdaCore.Tests
{
    
    public class PowerPlantTests
    {
        [Test]
        public void CreateCoreTest_WithValidInput()
        {
            // Arrange
            PowerPlant powerPlant = new PowerPlant();

            // Act
            powerPlant.CreateCore(TypeCore.SystemCore, 2000);

            // Assert
            Assert.AreEqual(1, powerPlant.Cores.Count);
        }

        [Test]
        public void CreateCoreTest_WithInvalidCoreType()
        {
            // Arrange
            PowerPlant powerPlant = new PowerPlant();

            // Act and Assert
            Assert.Throws<InvalidCoreTypeException>(() => powerPlant.CreateCore((TypeCore)99, 100));
        }

        [Test]
        public void RemoveCoreTest_WithValidCoreName()
        {
            // Arrange
            PowerPlant powerPlant = new PowerPlant();
            powerPlant.CreateCore(TypeCore.SystemCore, 2000);

            // Act
            powerPlant.RemoveCore("A");

            // Assert
            Assert.AreEqual(0, powerPlant.Cores.Count);
        }

        [Test]
        public void RemoveCoreTest_WithInvalidCoreName()
        {
            // Arrange
            PowerPlant powerPlant = new PowerPlant();
            powerPlant.CreateCore(TypeCore.SystemCore, 2000);

            // Act and Assert
            Assert.DoesNotThrow(() => powerPlant.RemoveCore("NonExistentCore"));

        }

        [Test]
        public void SelectCoreTest_WithValidCoreName()
        {
            // Arrange
            PowerPlant powerPlant = new PowerPlant();
            powerPlant.CreateCore(TypeCore.SystemCore, 2000);

            // Act
            powerPlant.SelectCore("A");

            // Assert
            Assert.NotNull(powerPlant.SelectedCore);
        }

        [Test]
        public void SelectCoreTest_WithInvalidCoreName()
        {
            // Arrange
            PowerPlant powerPlant = new PowerPlant();

            // Act and Assert
            Assert.DoesNotThrow(() => powerPlant.RemoveCore("NonExistentCore"));
        }

        [Test]
        public void FindCoreTest_WithValidCoreName()
        {
            //Arrange
            PowerPlant powerPlant = new PowerPlant();
            powerPlant.CreateCore(TypeCore.SystemCore, 2000);

            //Act
            Core core = powerPlant.FindCoreByName("A");

            //Assert
            Assert.IsTrue(core != null);
        }

        [Test]
        public void FindCoreTest_WithInvalidCoreName()
        {
            //Arrange
            PowerPlant powerPlant = new PowerPlant();

            //Act and Assert
            Assert.Throws<FailedFindCoreException>(() => powerPlant.FindCoreByName("A"));
        }

        [Test]
        public void AttachFragmentTest_WithValidFragmentType()
        {
            // Arrange
            PowerPlant powerPlant = new PowerPlant();
            powerPlant.CreateCore(TypeCore.SystemCore, 2000);
            powerPlant.SelectCore("A");
            string fragmentName = "A64";
            int pressureAffection = 100;
            FragmentType type = FragmentType.NuclearFragment;

            // Act
            powerPlant.AttachFragment(fragmentName, pressureAffection, type);

            // Assert
            Assert.AreEqual(1, powerPlant.SelectedCore.Fragments.Count);
        }

        [Test]
        public void AttachFragmentTest_WithInvalidFragmentType()
        {
            //Arrange
            PowerPlant powerPlant = new PowerPlant();
            powerPlant.CreateCore(TypeCore.SystemCore, 2000);
            powerPlant.SelectCore("A");

            //Act and Assert
            Assert.Throws<InvalidFragmentTypeException>(() => powerPlant.AttachFragment("A64", 100, (FragmentType)10));
        }

        [Test]
        public void AttachFragmentTest_WithNoSelectedCore()
        {
            //Arrange
            PowerPlant powerPlant = new PowerPlant();
            powerPlant.CreateCore(TypeCore.SystemCore, 2000);

            //Act and Assert
            Assert.Throws<InvalidFragmentTypeException>(() => powerPlant.AttachFragment("A64", 100, FragmentType.CoolingFragment));
        }

        [Test]
        public void DetachFragmentTest_WithSelectedCore()
        {
            // Arrange
            PowerPlant powerPlant = new PowerPlant();
            powerPlant.CreateCore(TypeCore.SystemCore, 2000);
            powerPlant.SelectCore("A");
            string fragmentName = "A64";
            int pressureAffection = 100;
            FragmentType type = FragmentType.NuclearFragment;
            powerPlant.AttachFragment(fragmentName, pressureAffection, type);

            // Act
            powerPlant.DetachFragment();

            // Assert
            Assert.AreEqual(0, powerPlant.SelectedCore.Fragments.Count);
        }

        [Test]
        public void DetachFragmentTest_NoSelectedCore()
        {
            // Arrange
            PowerPlant powerPlant = new PowerPlant();

            // Act and Assert
            Assert.Throws<FailedDetachException>(() => powerPlant.DetachFragment());
        }

        [Test]
        public void DetachFragmentTest_CoreHasNoFragments()
        {
            // Arrange
            PowerPlant powerPlant = new PowerPlant();
            powerPlant.CreateCore(TypeCore.SystemCore, 100);
            powerPlant.SelectCore("A");

            // Act and Assert
            Assert.Throws<FailedDetachException>(() => powerPlant.DetachFragment());
        }

        [Test]
        public void ToStringTest()
        {
            // Arrange
            PowerPlant powerPlant = new PowerPlant();
            powerPlant.CreateCore(TypeCore.SystemCore, 100);
            powerPlant.CreateCore(TypeCore.ParaCore, 80);

            // Act
            string result = powerPlant.ToString();

            // Assert
            StringAssert.Contains("Total Durability: 126", result);
            StringAssert.Contains("Total Cores: 2", result);
            StringAssert.Contains("Total Fragments: 0", result);
        }

        [Test]
        public void CoreTest_WithValidArguments()
        {
            // Arrange
            TypeCore type = TypeCore.SystemCore;
            string coreName = "A";
            int durability = 100;

            // Act
            SystemCore core = new SystemCore(type, coreName, durability);

            // Assert
            Assert.AreEqual(type, core.Type);
            Assert.AreEqual(coreName, core.CoreName);
            Assert.AreEqual(durability, core.Durability);
        }

        [Test]
        public void CoreTest_WithInvalidDurability()
        {
            // Arrange
            TypeCore type = TypeCore.ParaCore;
            string coreName = "A";
            int durability = -10;

            // Act and Assert
            Assert.DoesNotThrow(() => new ParaCore(type, coreName, durability));
        }

        [Test]
        public void CoreTest_WithInvalidCoreType()
        {
            // Arrange
            TypeCore type = (TypeCore)999;
            string coreName = "A";
            int durability = 50;

            // Act and Assert
            Assert.DoesNotThrow(() => new SystemCore(type, coreName, durability));
        }

        [Test]
        public void CoreTest_WithInvalidCoreName()
        {
            // Arrange
            TypeCore type = TypeCore.SystemCore;
            string coreName = "";
            int durability = 75;

            // Act and Assert
            Assert.DoesNotThrow(() => new SystemCore(type, coreName, durability));
        }

        [Test]
        public void AddFragmentTest()
        {
            // Arrange
            SystemCore systemCore = new SystemCore(TypeCore.SystemCore, "A", 2000);
            CoolingFragment fragment = new CoolingFragment(FragmentType.CoolingFragment, "A64", 100);

            // Act
            systemCore.AddFragment(fragment);

            // Assert
            Assert.Contains(fragment, systemCore.Fragments);
        }

        [Test]
        public void RemoveFragmentTest()
        {
            // Arrange
            SystemCore systemCore = new SystemCore(TypeCore.SystemCore, "A", 2000);
            CoolingFragment fragment = new CoolingFragment(FragmentType.CoolingFragment, "A64", 100);
            systemCore.AddFragment(fragment);

            // Act
            systemCore.RemoveFragment(fragment);

            // Assert
            Assert.AreEqual(0, systemCore.Fragments.Count);
        }
    }
}