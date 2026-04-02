using Demo.Domain;
using System.Collections.Generic;
using UnityEngine;

namespace Demo.Application
{
    public class AttackPipeline
    {
        public AttackPipeline(IAttackStep[] attackSteps)
        {
            _attackSteps = attackSteps;
        }

        public IReadOnlyList<IAttackStep> AttackSteps => _attackSteps;

        private readonly IAttackStep[] _attackSteps;
    }
}
