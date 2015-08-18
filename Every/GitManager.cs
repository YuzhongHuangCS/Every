using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace Every {
    class GitManager {
        private Repository repo;

        public GitManager(string path) {
            repo = new Repository(path);
        }


    }
}
