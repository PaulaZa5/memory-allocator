using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace memory_allocation_gui_app
{
    public partial class memAllocator : Form
    {
        private int memory_size = 0;
        private List<hole> holes = new List<hole>();
        private List<process> processes = new List<process>();
        private int processesNamesCount = 0;

        private struct hole
        {
            public int startAddress;
            public int endAddress;
        }
        private struct process
        {
            public string name;
            public int startAddress;
            public int endAddress;
        }

        private void addHole(int startAddress, int endAddress)
        {
            if (endAddress > memory_size)
            {
                MessageBox.Show("You cannot have a hole outside of the memory size.");
                return;
            }
            hole newHole;
            newHole.startAddress = startAddress;
            newHole.endAddress = endAddress;
            int hc = holes.Count();
            if (hc == 0)
            {
                holes.Add(newHole);
                return;
            }
            for (int i = 0; i < hc; i++)
            {
                if (newHole.startAddress <= holes[i].startAddress)
                {
                    int insertAtIndex = i;
                    if (i != 0)
                        if (holes[i - 1].endAddress >= newHole.startAddress)
                        {
                            newHole.startAddress = holes[i - 1].startAddress;
                            holes.RemoveAt(i - 1);
                            insertAtIndex = i - 1;
                        }
                    if (holes.Count() != hc)
                    {
                        i = insertAtIndex;
                    }
                    while (i != holes.Count())
                    {
                        if (holes[i].startAddress <= newHole.endAddress)
                        {
                            if (holes[i].endAddress > newHole.endAddress)
                                newHole.endAddress = holes[i].endAddress;
                            holes.RemoveAt(i);
                        }
                        else
                            break;
                    }
                    holes.Insert(insertAtIndex, newHole);
                    return;
                }
            }
            if (holes[hc - 1].endAddress >= newHole.startAddress)
            {
                newHole.startAddress = holes[hc - 1].startAddress;
                holes.RemoveAt(hc - 1);
            }
            holes.Add(newHole);
        }
        private void removeHole(int startAddress, int endAddress)
        {
            int hc = holes.Count();
            for (int i = 0; i < hc; i++)
            {
                if (holes[i].startAddress == startAddress)
                {
                    if (holes[i].endAddress == endAddress)
                        holes.RemoveAt(i);
                    else
                    {
                        hole newHole;
                        newHole.startAddress = endAddress;
                        newHole.endAddress = holes[i].endAddress;
                        holes.RemoveAt(i);
                        holes.Insert(i, newHole);
                    }
                    return;
                }
            }
        }

        private void compactMemory()
        {
            int pc = processes.Count(), accumilatedAddresses = 0;
            for (int i = 0, prevProcessEndAddress = 0, processSize = 0; i < pc; i++)
            {
                prevProcessEndAddress = processes[i].endAddress;
                processSize = processes[i].endAddress - processes[i].startAddress;
                process tempP = new process();
                tempP.name = processes[i].name;
                tempP.startAddress = accumilatedAddresses;
                tempP.endAddress = accumilatedAddresses + processSize;
                processes[i] = tempP;
                accumilatedAddresses = processes[i].endAddress;
            }
            holes = new List<hole>();
            hole tempH = new hole();
            tempH.startAddress = accumilatedAddresses;
            tempH.endAddress = memory_size;
            holes.Add(tempH);
            draw();
            return;
        }

        private int firstFit(int processSize)
        {
            int hc = holes.Count();
            int leastStartAddress = int.MaxValue;
            int leastStartIndex = -1;
            for (var i = hc - 1; i >= 0; i--)
            {
                if ((leastStartAddress > holes[i].startAddress) && (processSize <= holes[i].endAddress - holes[i].startAddress))
                {
                    leastStartIndex = i;
                    leastStartAddress = holes[i].startAddress;
                }
            }
            return leastStartIndex;
        }
        private int bestFit(int processSize)
        {
            int hc = holes.Count();
            int leastSize = int.MaxValue;
            int leastSizeIndex = -1;
            for (var i = hc - 1; i >= 0; i--)
            {
                if ((leastSize > holes[i].endAddress - holes[i].startAddress) && (processSize <= holes[i].endAddress - holes[i].startAddress))
                {
                    leastSizeIndex = i;
                    leastSize = holes[i].endAddress - holes[i].startAddress;
                }
            }
            return leastSizeIndex;
        }
        private int worstFit(int processSize)
        {
            int hc = holes.Count();
            int maxSize = int.MinValue;
            int maxSizeIndex = -1;
            for (var i = hc - 1; i >= 0; i--)
            {
                if ((maxSize < holes[i].endAddress - holes[i].startAddress) && (processSize <= holes[i].endAddress - holes[i].startAddress))
                {
                    maxSizeIndex = i;
                    maxSize = holes[i].endAddress - holes[i].startAddress;
                }
            }
            return maxSizeIndex;
        }
        private void changeProcessesInputNo()
        {
            processNameLbl.Text = "Process #" + (processes.Count + 1).ToString() + " Name: ";
            processSizeLbl.Text = "Process #" + (processes.Count() + 1).ToString() + " Size: ";
            processSizeTxt.Text = "Process Size";
        }
        private void addProcess(string processName, int size)
        {
            int holeIndex = -1;
            if (firstFitRad.Checked == true)
            {
                holeIndex = firstFit(size);
            }
            else if (bestFitRad.Checked == true)
            {
                holeIndex = bestFit(size);
            }
            else if (worstFitRad.Checked == true)
            {
                holeIndex = worstFit(size);
            }
            if (holeIndex == -1)
            {
                MessageBox.Show("We couldn't allocate memory for this process because there is no fit.\nTry again after deallocating some other processes.");
                return;
            }
            processesNamesCount = processesNamesCount + 1;
            processNameTxt.Text = "P" + (processesNamesCount + 1).ToString();
            process newProcess;
            newProcess.name = processName;
            newProcess.startAddress = holes[holeIndex].startAddress;
            newProcess.endAddress = newProcess.startAddress + size;
            removeHole(newProcess.startAddress, newProcess.endAddress);
            int pc = processes.Count();
            if (pc == 0)
            {
                processes.Add(newProcess);
            }
            else
            {
                for (int insertAtIndex = 0; insertAtIndex < pc; insertAtIndex++)
                    if (processes[insertAtIndex].startAddress > newProcess.startAddress)
                    {
                        processes.Insert(insertAtIndex, newProcess);
                        return;
                    }
                processes.Add(newProcess);
            }
            changeProcessesInputNo();
            draw();
        }
        private void removeProcess(int index)
        {
            addHole(processes[index].startAddress, processes[index].endAddress);
            processes.RemoveAt(index);
            changeProcessesInputNo();
            draw();
        }

        private List<Color> used_colors = new List<Color>();
        private List<string> used_processes = new List<string>();
        private int no_used_processes = 0;
        Random rand = new Random();
        private Color determine_process_color(string process)
        {
            if (process == "Hole")
            {
                return Color.FromArgb(24, 195, 87);
            }
            for (int i = 0; i < no_used_processes; i++)
                if (process == used_processes[i])
                    return used_colors[i];

            Color result = Color.FromArgb(rand.Next(-16777216, 0));
            used_processes.Add(process);
            used_colors.Add(result);
            no_used_processes++;

            return result;
        }

        private List<Label> output_labels = new List<Label>();
        private List<Label> addresses_labels = new List<Label>();
        private void delete_labels()
        {
            int labels_no = output_labels.Count();
            for (int i = 0; i < labels_no; i++)
            {
                output_labels[i].Dispose();
            }
            labels_no = addresses_labels.Count();
            for (int i = 0; i < labels_no; i++)
            {
                addresses_labels[i].Dispose();
            }
            output_labels = new List<Label>();
            addresses_labels = new List<Label>();
        }
        private void draw()
        {
            delete_labels();
            int reached_length = 20, size = 0, start = 0, end = 0, iHoles = 0, nh = holes.Count(), iProcesses = 0, np = processes.Count();
            int totalSpaces = nh + np;
            string name = "";
            for (var i = 0; i < totalSpaces; i++)
            {
                if (iHoles != nh && iProcesses != np)
                {
                    if (holes[iHoles].startAddress < processes[iProcesses].startAddress)
                    {
                        start = holes[iHoles].startAddress;
                        end = holes[iHoles].endAddress;
                        size = end - start;
                        name = "Hole";
                        iHoles++;
                    }
                    else
                    {
                        start = processes[iProcesses].startAddress;
                        end = processes[iProcesses].endAddress;
                        size = end - start;
                        name = processes[iProcesses].name;
                        iProcesses++;
                    }
                }
                else if (iHoles != nh)
                {
                    start = holes[iHoles].startAddress;
                    end = holes[iHoles].endAddress;
                    size = end - start;
                    name = "Hole";
                    iHoles++;
                }
                else if (iProcesses != np)
                {
                    start = processes[iProcesses].startAddress;
                    end = processes[iProcesses].endAddress;
                    size = end - start;
                    name = processes[iProcesses].name;
                    iProcesses++;
                }

                Label addressLbl1 = new Label();
                outputPnl.Controls.Add(addressLbl1);
                addressLbl1.AutoSize = true;
                addressLbl1.BackColor = Color.Transparent;
                addressLbl1.Location = new Point(15, reached_length - 7);
                addressLbl1.TextAlign = ContentAlignment.MiddleCenter;
                addressLbl1.Text = start.ToString();
                addresses_labels.Add(addressLbl1);

                Label lbl = new Label();
                outputPnl.Controls.Add(lbl);
                lbl.AutoSize = false;
                lbl.Size = new Size(160, (int)Math.Ceiling((double)size * outResizeBar.Value));
                lbl.Location = new Point(40, reached_length);
                reached_length += lbl.Size.Height - 1;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Text = name;
                lbl.BackColor = determine_process_color(name);
                if (name != "Hole")
                {
                    lbl.Name = (iProcesses - 1).ToString();
                    lbl.DoubleClick += (s, ea) => {
                        Label temp = (Label)s;
                        removeProcess(Int32.Parse(temp.Name));
                    };
                }
                output_labels.Add(lbl);

                Label addressLbl2 = new Label();
                outputPnl.Controls.Add(addressLbl2);
                addressLbl2.AutoSize = true;
                addressLbl2.BackColor = Color.Transparent;
                addressLbl2.Location = new Point(15, reached_length - 7);
                addressLbl2.TextAlign = ContentAlignment.MiddleCenter;
                addressLbl2.Text = end.ToString();
                addresses_labels.Add(addressLbl2);
            }
        }
        
        public memAllocator()
        {
            InitializeComponent();
            this.Size = new Size(500, 112);

            outputPnl.AutoScroll = false;
            outputPnl.HorizontalScroll.Enabled = false;
            outputPnl.HorizontalScroll.Visible = false;
            outputPnl.HorizontalScroll.Maximum = 0;
            outputPnl.AutoScroll = true;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (memorySizeTxt.Enabled == true)
            {
                if (Int32.TryParse(memorySizeTxt.Text, out memory_size) && memory_size > 0)
                {
                    this.Size = new Size(500, 138);
                    memorySizeTxt.Enabled = false;
                    holeSizeLbl.Enabled = true;
                    holeSizeLbl.Visible = true;
                    holeSizeTxt.Enabled = true;
                    holeSizeTxt.Visible = true;
                    holeStartAddressLbl.Enabled = true;
                    holeStartAddressLbl.Visible = true;
                    holeStartAddressTxt.Enabled = true;
                    holeStartAddressTxt.Visible = true;
                    addBtn.Enabled = true;
                    addBtn.Visible = true;
                    outResizeLbl.Enabled = true;
                    outResizeLbl.Visible = true;
                    outResizeBar.Enabled = true;
                    outResizeBar.Visible = true;
                    submitBtn.Location = new Point(316, 64);
                }
                else
                {
                    MessageBox.Show("You can't enter anything but positive numbers.");
                    memorySizeTxt.Text = "Memory Size";
                    memorySizeTxt.ForeColor = SystemColors.InactiveCaption;
                }
            }
            else if (holeSizeTxt.Enabled == true)
            {
                this.Size = new Size(734, 500); // This = 734, 229 | Panel = 228, 166 | outResizeBar.Location = 12, 119 | outResizeLbl.Location = 178, 153
                outputPnl.Size = new Size(228, 437);
                if (holeStartAddressTxt.Text != "Hole Start Address" && holeSizeTxt.Text != "Hole Size")
                {
                    addHole(Convert.ToInt32(holeStartAddressTxt.Text), Convert.ToInt32(holeStartAddressTxt.Text) + Convert.ToInt32(holeSizeTxt.Text));
                }
                holeStartAddressTxt.Text = "Hole Start Address";
                holeSizeTxt.Text = "Hole Size";
                holeSizeTxt.Enabled = false;
                holeStartAddressTxt.Enabled = false;
                processNameLbl.Enabled = true;
                processNameLbl.Visible = true;
                processNameTxt.Enabled = true;
                processNameTxt.Visible = true;
                processSizeLbl.Enabled = true;
                processSizeLbl.Visible = true;
                processSizeTxt.Enabled = true;
                processSizeTxt.Visible = true;
                firstFitRad.Enabled = true;
                firstFitRad.Visible = true;
                bestFitRad.Enabled = true;
                bestFitRad.Visible = true;
                worstFitRad.Enabled = true;
                worstFitRad.Visible = true;
                submitBtn.Text = "Reset";
                submitBtn.Location = new Point(235, 90);
                compactBtn.Enabled = true;
                compactBtn.Visible = true;
                addBtn.Text = "Add Process";
                addBtn.Location = new Point(397, 90);

                int hc = holes.Count(), i = 0;
                if (hc == 0)
                {
                    process newProcess = new process();
                    newProcess.name = "Reserved " + i.ToString();
                    newProcess.startAddress = 0;
                    newProcess.endAddress = memory_size;
                    processes.Add(newProcess);
                }
                else if (hc == 1)
                {
                    if (holes[0].startAddress != 0)
                    {
                        process newProcess = new process();
                        newProcess.name = "Reserved 0";
                        newProcess.startAddress = 0;
                        newProcess.endAddress = holes[0].startAddress;
                        processes.Add(newProcess);
                    }
                    if (holes[0].endAddress != memory_size)
                    {
                        process newProcess2 = new process();
                        newProcess2.name = "Reserved 1";
                        newProcess2.startAddress = holes[0].endAddress;
                        newProcess2.endAddress = memory_size;
                        processes.Add(newProcess2);
                    }
                }
                else
                {
                    while (i < hc)
                    {
                        if (i == 0 && holes[0].startAddress != 0)
                        {
                            process newProcess = new process();
                            newProcess.name = "Reserved " + i.ToString();
                            newProcess.startAddress = 0;
                            newProcess.endAddress = holes[0].startAddress;
                            processes.Add(newProcess);
                        }
                        else if (i == hc - 1)
                        {
                            process newProcess = new process();
                            newProcess.name = "Reserved " + i.ToString();
                            newProcess.startAddress = holes[i - 1].endAddress;
                            newProcess.endAddress = holes[i].startAddress;
                            processes.Add(newProcess);
                            if (holes[i].endAddress != memory_size)
                            {
                                process newProcess2 = new process();
                                newProcess2.name = "Reserved " + (i + 1).ToString();
                                newProcess2.startAddress = holes[i].endAddress;
                                newProcess2.endAddress = memory_size;
                                processes.Add(newProcess2);
                            }
                        }
                        else if (i != 0)
                        {
                            process newProcess = new process();
                            newProcess.name = "Reserved " + i.ToString();
                            newProcess.startAddress = holes[i - 1].endAddress;
                            newProcess.endAddress = holes[i].startAddress;
                            processes.Add(newProcess);
                        }
                        i++;
                    }
                }
                changeProcessesInputNo();
                draw();
            }
            else if (processSizeTxt.Enabled == true)
            {
                memAllocator n = new memAllocator();
                n.Show();
                this.Dispose(false);
            }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (holeSizeTxt.Enabled)
            {
                if (holeStartAddressTxt.Text != "Hole Start Address" && holeSizeTxt.Text != "Hole Size")
                {
                    addHole(Convert.ToInt32(holeStartAddressTxt.Text), Convert.ToInt32(holeStartAddressTxt.Text) + Convert.ToInt32(holeSizeTxt.Text));
                    holeStartAddressLbl.Text = "Hole #" + (holes.Count() + 1).ToString() + " Start Address: ";
                    holeStartAddressTxt.Text = "Hole Start Address";
                    holeStartAddressTxt.ForeColor = SystemColors.InactiveCaption;
                    holeSizeLbl.Text = "Hole #" + (holes.Count() + 1).ToString() + " Size: ";
                    holeSizeTxt.Text = "Hole Size";
                    holeSizeTxt.ForeColor = SystemColors.InactiveCaption;
                }
                else
                {
                    MessageBox.Show("Please complete the required fields before trying to add a hole.");
                }
            }
            else if (processSizeTxt.Enabled)
            {
                if (processSizeTxt.Text != "Process Size")
                {
                    addProcess(processNameTxt.Text, Convert.ToInt32(processSizeTxt.Text));
                    processSizeTxt.Text = "Process Size";
                    processSizeTxt.ForeColor = SystemColors.InactiveCaption;
                    draw();
                }
                else
                {
                    MessageBox.Show("Please complete the required fields before trying to add a process.");
                }
            }
        }
        private void compactBtn_Click(object sender, EventArgs e)
        {
            compactMemory();
        }
        private void outResizeBar_Scroll(object sender, EventArgs e)
        {
            draw();
        }

        private void memorySizeTxt_Enter(object sender, EventArgs e)
        {
            if (memorySizeTxt.Text == "Memory Size")
            {
                memorySizeTxt.Text = "";
                memorySizeTxt.ForeColor = SystemColors.WindowText;
            }
        }
        private void memorySizeTxt_Leave(object sender, EventArgs e)
        {
            int outParse = 0;
            if (memorySizeTxt.Text == "")
            {
                memorySizeTxt.Text = "Memory Size";
                memorySizeTxt.ForeColor = SystemColors.InactiveCaption;
            }
            else if (!Int32.TryParse(memorySizeTxt.Text, out outParse) || outParse <= 0)
            {
                MessageBox.Show("You can't enter anything but positive numbers.");
                memorySizeTxt.Text = "Memory Size";
                memorySizeTxt.ForeColor = SystemColors.InactiveCaption;

            }
        }
        private void holeStartAddressTxt_Enter(object sender, EventArgs e)
        {
            if (holeStartAddressTxt.Text == "Hole Start Address")
            {
                holeStartAddressTxt.Text = "";
                holeStartAddressTxt.ForeColor = SystemColors.WindowText;
            }
        }
        private void holeStartAddressTxt_Leave(object sender, EventArgs e)
        {
            int outParse = 0;
            if (holeStartAddressTxt.Text == "")
            {
                holeStartAddressTxt.Text = "Hole Start Address";
                holeStartAddressTxt.ForeColor = SystemColors.InactiveCaption;
            }
            else if (!Int32.TryParse(holeStartAddressTxt.Text, out outParse) || outParse < 0)
            {
                MessageBox.Show("You can't enter anything but positive numbers.");
                holeStartAddressTxt.Text = "Hole Start Address";
                holeStartAddressTxt.ForeColor = SystemColors.InactiveCaption;

            }
        }
        private void holeSizeTxt_Enter(object sender, EventArgs e)
        {
            if (holeSizeTxt.Text == "Hole Size")
            {
                holeSizeTxt.Text = "";
                holeSizeTxt.ForeColor = SystemColors.WindowText;
            }
        }
        private void holeSizeTxt_Leave(object sender, EventArgs e)
        {
            int outParse = 0;
            if (holeSizeTxt.Text == "")
            {
                holeSizeTxt.Text = "Hole Size";
                holeSizeTxt.ForeColor = SystemColors.InactiveCaption;
            }
            else if (!Int32.TryParse(holeSizeTxt.Text, out outParse) || outParse <= 0)
            {
                MessageBox.Show("You can't enter anything but positive numbers.");
                holeSizeTxt.Text = "Hole Size";
                holeSizeTxt.ForeColor = SystemColors.InactiveCaption;

            }
        }
        private void processNameTxt_Enter(object sender, EventArgs e)
        {
            if (processNameTxt.Text == "P" + (processesNamesCount + 1).ToString())
            {
                processNameTxt.Text = "";
            }
        }
        private void processNameTxt_Leave(object sender, EventArgs e)
        {
            if (processNameTxt.Text == "")
            {
                processNameTxt.Text = "P" + (processesNamesCount + 1).ToString();
            }
        }
        private void processSizeTxt_Enter(object sender, EventArgs e)
        {
            if (processSizeTxt.Text == "Process Size")
            {
                processSizeTxt.Text = "";
                processSizeTxt.ForeColor = SystemColors.WindowText;
            }
        }
        private void processSizeTxt_Leave(object sender, EventArgs e)
        {
            int outParse = 0;
            if (processSizeTxt.Text == "")
            {
                processSizeTxt.Text = "Process Size";
                processSizeTxt.ForeColor = SystemColors.InactiveCaption;
            }
            else if (!Int32.TryParse(processSizeTxt.Text, out outParse) || outParse < 0)
            {
                MessageBox.Show("You can't enter anything but positive numbers.");
                processSizeTxt.Text = "Process Size";
                processSizeTxt.ForeColor = SystemColors.InactiveCaption;

            }
        }
    }
}
