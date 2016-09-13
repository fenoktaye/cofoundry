﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cofoundry.Core.AutoUpdate
{
    /// <summary>
    /// Simple factory for creating a DB script update package using default conventions.
    /// </summary>
    public abstract class BaseDbOnlyUpdatePackageFactory : IUpdatePackageFactory
    {
        /// <summary>
        /// Unique identifier for this module.
        /// </summary>
        public abstract string ModuleIdentifier { get; }

        /// <summary>
        /// A collection of module identifiers that this module is dependent on.
        /// </summary>
        public virtual IEnumerable<string> DependentModules { get { return Enumerable.Empty<string>();} }

        /// <summary>
        /// The folder path of the script files which defaults to 'Install.Db.' (which equates to 'Install/Db/')
        /// </summary>
        public virtual string ScriptPath { get { return "Install.Db."; } }

        public IEnumerable<UpdatePackage> Create(IEnumerable<ModuleVersion> versionHistory)
        {
            var moduleVersion = versionHistory.SingleOrDefault(m => m.Module == ModuleIdentifier);

            var package = new UpdatePackage();
            var dbCommandFactory = new DbUpdateCommandFactory();

            package.Commands = dbCommandFactory.Create(GetType().Assembly, moduleVersion, ScriptPath);
            package.ModuleIdentifier = ModuleIdentifier;
            package.DependentModules = DependentModules;

            yield return package;
        }
    }
}
