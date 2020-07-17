import React from 'react'
import { TableProps } from "./Types/TableProps";
import { Link } from 'react-router-dom';

export const Table: React.FC<TableProps> = (props) =>
    <React.Fragment>
        <h2>{props.Title} <Link to={props.AddItemUrl} className="btn btn-success">Add</Link></h2>
        <div className="table-responsive">
            <table className="table table-striped table-sm">
                <thead>
                    <tr>
                        <th key={0}>#</th>
                        {
                            props.Header.map((item, index) => <th key={index + 1}>{item.Name}</th>)
                        }
                        <th key={props.Header.length + 1} colSpan={props.ActionsCount}>Actions</th>
                    </tr>
                </thead >
                <tbody>
                    {
                        props.RenderBody()
                    }
                </tbody>
            </table>
        </div>
    </React.Fragment>
