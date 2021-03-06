﻿using Fork.ViewModels.Project.Member;
using System.Collections.Generic;

namespace Fork.ViewModels.Project
{
    /// <summary>
    /// Represents what a Project is.
    /// </summary>
    public class BasicDataProject
    {
        /// <summary>
        /// Project id.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Project Type id.
        /// </summary>
        public int ProjectTypeId { get; set; }

        /// <summary>
        /// Project Type name.
        /// </summary>
        public string ProjectTypeName { get; set; }

        /// <summary>
        /// Project name.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Project headline.
        /// </summary>
        public string ProjectHeadline { get; set; }

        /// <summary>
        /// Project pitch.
        /// </summary>
        public string ProjectPitch { get; set; }

        /// <summary>
        /// Project Semester id.
        /// </summary>
        public int SemesterId { get; set; }

        /// <summary>
        /// Project Semester name.
        /// </summary>
        public string SemesterName { get; set; }

        /// <summary>
        /// Project Storage id.
        /// </summary>
        public int StorageId { get; set; }

        /// <summary>
        /// Current project members list.
        /// </summary>
        public IEnumerable<DetailedDataProjectMember> Members { get; set; }

        /// <summary>
        /// Project Stall state.
        /// </summary>
        public bool OpenedStall { get; set; }

        /// <summary>
        /// Project linked votes.
        /// </summary>
        public IEnumerable<int> Votes { get; set; }
    }
}
