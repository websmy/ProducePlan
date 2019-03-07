select top 10 SO_SODetails.cSOCode,mom_order.mocode,rdrecord.ccode,rdrecord.ddate, Department.cDepname, rdrecords.cInvCode,Inventory.cinvname, mom_orderdetail.qty, rdrecords.iquantity,rdrecords.iunitcost,rdrecords.iquantity * rdrecords.iunitcost as totalprice 
from rdrecords 
left join rdrecord on rdrecords.id=rdrecord.id
left join SO_SODetails on rdrecords.isodid=SO_SODetails.isosid
left join mom_orderdetail on rdrecords.impoids=mom_orderdetail.modid
left join mom_order ON mom_orderdetail.moid = mom_order.moid
left join Inventory on rdrecords.cInvCode = inventory.cinvcode
left join Department on rdrecord.cDepCode=Department.cDepCode

where rdrecord.cBusType='³ÉÆ·Èë¿â'