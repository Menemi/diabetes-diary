import React from "react";
import {
  CategoryScale,
  Chart as ChartJS,
  Legend,
  LinearScale,
  LineElement,
  PointElement,
  Title,
  Tooltip,
} from "chart.js";
import {Line} from "react-chartjs-2";

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);

ChartJS.defaults.color = "white";

export default function BarDiagram(dataset, labels, titleDates) {
  const options = {
    responsive: true,
    plugins: {
      legend: {
        position: "none",
      },
      title: {
        display: true,
        text: `Средние сахара за ${titleDates}`,
        color: "white",
      }
    }
  };

  const data = {
    labels,
    datasets: [
      {
        data: dataset,
        borderColor: "rgba(116, 33, 72, 1)",
        backgroundColor: "rgba(116, 33, 72, 0.5)",
      }
    ],
  };

  return (
    <div className="single-diagram-wrapper">
      <Line className="single-diagram" options={options} data={data}/>
    </div>
  )
}