using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEquipment2
{
    public class Equipment
    {
        private int id;
        private int type;
        private int mtype;
        private string releaser;
        private DateTime releaseDate;
        private DateTime checkDate;
        private int typeCheck;
        private bool checkResult;
        private DateTime beginCheckDate;
        private DateTime reloadDate;
        private DateTime beginReloadDate;
        private int locPoint;

        public Equipment
        (
            int _id,
            int _type,
            int _mtype,
            string _releaser,
            DateTime _releaseDate,
            DateTime _checkDate,
            int _typeCheck,
            bool _checkResult,
            DateTime _beginCheckDate,
            DateTime _reloadDate,
            DateTime _beginReloadDate,
            int _locPoint
        )
        {
            id = _id;
            type = _type;
            mtype = _mtype;
            releaser = _releaser;
            releaseDate = _releaseDate;
            checkDate = _checkDate;
            typeCheck = _typeCheck;
            checkResult = _checkResult;
            beginCheckDate = _beginCheckDate;
            reloadDate = _reloadDate;
            beginReloadDate = _beginReloadDate;
            locPoint = _locPoint;
        }
    }
}


 /*equipment = new Equipment(id,
                                          int.Parse(tbType.Text),
                                          int.Parse(tbMType.Text),
                                          tbReleaser.Text,
                                          DateTime.Parse(tbReleaseDate.Text),
                                          DateTime.Parse(tbCheckDate.Text),
                                          int.Parse(tbCheckType.Text),
                                          cbPResult.CheckState == CheckState.Checked,
                                          DateTime.Parse(tbBCheckDate.Text),
                                          DateTime.Parse(tbReloadDate.Text),
                                          DateTime.Parse(tbBReloadDate.Text),
                                          locpoint);
                */
