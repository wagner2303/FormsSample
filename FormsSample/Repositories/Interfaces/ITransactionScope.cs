//
//  ITransactionScope.cs
//
//  Author:
//       Wagner Teixeira <wagner2303@gmail.com>
//
//  Copyright (c) 2017 
//

namespace FormsSample.Repositories.Interfaces {
	public interface ITransactionScope {
		string BeginTransaction();
		void EndTransaction(string savePointId);
		void RollBack(string savePointId);
		void Complete();
	}
}
