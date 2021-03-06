USE [UFDATA_999_2013]

GO

/****** Object:  View [dbo].[aViewName]    Script Date: 09/13/2013 10:12:38 ******/
SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

ALTER VIEW [dbo].[aViewName]
AS
  SELECT a.moid,
         a.SortSeq,
         Department.[cDepName],
         a.modid,
         a.MDeptCode,
         inventory.cinvdefine4,
         inventory.[cInvCode],
         a.SoCode,
         mom_order.mocode,
         a.InvCode,
         inventory.cinvname,
         a.Qty,
         a.QualifiedInQty,
         mom_morder.startdate,
         mom_morder.Duedate,
         是否缺料= (SELECT CASE
                                 WHEN (SELECT Count(*)
                                       FROM   mom_moallocate
                                              LEFT JOIN mom_orderdetail
                                                     ON mom_moallocate.modid = mom_orderdetail.modid
                                              LEFT JOIN inventory
                                                     ON mom_moallocate.invcode = inventory.cinvcode
                                              LEFT JOIN CurrentStock
                                                     ON CurrentStock.cWhCode = mom_moallocate.whcode
                                                        AND CurrentStock.cInvCode = mom_moallocate.InvCode
                                       WHERE  mom_moallocate.modid = a.modid
                                              AND mom_moallocate.qty - mom_moallocate.issqty > Isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity, 0)) > 0 THEN '是'
                                 ELSE '否'
                               END)
  FROM   mom_orderdetail a
         LEFT JOIN mom_order
                ON a.moid = mom_order.moid
         LEFT JOIN mom_morder
                ON a.modid = mom_morder.modid
         LEFT JOIN inventory
                ON a.InvCode = inventory.cInvCode
         LEFT JOIN [Department]
                ON a.MDeptCode = [Department].[cDepCode]
  WHERE  a.status <> 4

GO
