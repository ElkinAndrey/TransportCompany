import React from "react";
import PaginationBar from "../forms/paginationBar/PaginationBar";
import { useState } from "react";
import TransportTable from "./../../views/Tables/TransportTable/TransportTable";
import GarageFacilityCount from "./../../views/GarageFacilityCount/GarageFacilityCount";
import MileageByCategory from "./../../views/MileageByCategory/MileageByCategory";
import RepairInformationByCategory from "../../views/Repair/RepairInformationByCategory/RepairInformationByCategory";
import RepairInformationByBrand from "../../views/Repair/RepairInformationByBrand/RepairInformationByBrand";
import DetailsByCategory from './../../views/Repair/DetailsByCategory/DetailsByCategory';
import DetailsByBrand from './../../views/Repair/DetailsByBrand/DetailsByBrand';

const TransportsPage = () => {
  let [transportCount, setTransportCount] = useState(0);
  let [page, setPage] = useState(1);
  let [end, setEnd] = useState(1);
  let [c, setC] = useState(0);
  return (  
    <div>
      <div>Количество транспорта : {transportCount}</div>
      <GarageFacilityCount categoryId={c} />
      <MileageByCategory />
      <br />
      <RepairInformationByCategory />
      <RepairInformationByBrand />
      <DetailsByCategory />
      <DetailsByBrand />
      <br />
      <PaginationBar start={1} end={end} page={page} setPage={setPage} />
      <TransportTable
        page={page}
        setPage={setPage}
        setEnd={setEnd}
        setTransportCount={setTransportCount}
        setCategoryId={setC}
      />
    </div>
  );
};

export default TransportsPage;
