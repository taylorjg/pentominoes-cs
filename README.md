# TODO

* ~~De-dup the 520 solutions to 65 solutions~~
  * ~~i.e. ignore solutions that are just rotations or transpositions of other solutions~~
* ~~Implement `DrawSolution` functionally (currently, it mutates a 2D array of strings)~~
* Use immutable collections throughout

# Links

* https://en.wikipedia.org/wiki/Pentomino
* https://arxiv.org/pdf/cs/0011047v1.pdf
* https://www-cs-faculty.stanford.edu/~knuth/programs/polyominoes.w

# Output

```
$ dotnet run --project PentominoesApp --no-build
LLLLFYPP
LXFFFYPP
XXXFYYPI
UXU  YWI
UUU  WWI
VVVZWWTI
VZZZNNTI
VZNNNTTT
--------------------------------------------------------------------------------
LLLLNNPP
LXNNNTPP
XXXTTTPI
UXU  TWI
UUU  WWI
VVVZWWFI
VZZZYFFI
VZYYYYFF
--------------------------------------------------------------------------------
LLLLNNPP
LXNNNTPP
XXXTTTPY
UXU  TYY
UUU  WWY
VVVZWWFY
VZZZWFFF
VZIIIIIF
--------------------------------------------------------------------------------
UUULLLLY
UXULNNNY
XXXNNWYY
IXF  WWY
IFF  ZWW
ITFFVZZZ
ITTTVPPZ
ITVVVPPP
--------------------------------------------------------------------------------
UUUTLLLL
UXUTTTPL
XXXTZZPP
IXF  ZPP
IFF  ZZY
IVFFWWYY
IVNNNWWY
IVVVNNWY
--------------------------------------------------------------------------------
UUUTYYYY
UXUTTTYP
XXXTZZPP
IXF  ZPP
IFF  ZZW
IVFFNNWW
IVNNNWWL
IVVVLLLL
--------------------------------------------------------------------------------
UUUTYYYY
UXUTTTYP
XXXTZZPP
IXF  ZPP
IFF  ZZL
IVFFNNWL
IVNNNWWL
IVVVWWLL
--------------------------------------------------------------------------------
UUULLLLY
UXULNNNY
XXXNNWYY
IXF  WWY
IFF  ZWW
IVFFTZZZ
IVTTTPPZ
IVVVTPPP
--------------------------------------------------------------------------------
UUULLLLV
UXUPPPLV
XXXPPVVV
IXN  ZZY
INN  ZYY
INTWZZFY
INTWWFFY
ITTTWWFF
--------------------------------------------------------------------------------
UUUPPVVV
UXUPPPLV
XXXLLLLV
IXN  ZZY
INN  ZYY
INTWZZFY
INTWWFFY
ITTTWWFF
--------------------------------------------------------------------------------
UUUVLLLL
UXUVLPPP
XXXVVVPP
IXN  ZZY
INN  ZYY
INTWZZFY
INTWWFFY
ITTTWWFF
--------------------------------------------------------------------------------
UUUVVVFF
UXUVWFFL
XXXVWWFL
IXN  WWL
INN  ZLL
INTPPZZZ
INTPPPYZ
ITTTYYYY
--------------------------------------------------------------------------------
UUUVVVPP
UXUVLPPP
XXXVLLLL
IXN  ZZY
INN  ZYY
INTWZZFY
INTWWFFY
ITTTWWFF
--------------------------------------------------------------------------------
UUUVVVZY
UXUVZZZY
XXXVZWYY
IXN  WWY
INN  FWW
INTPPFFF
INTPPPFL
ITTTLLLL
--------------------------------------------------------------------------------
UUUPPTTT
UXUPPPTY
XXXVVVTY
IXN  VYY
INN  VFY
INZZWWFF
INZWWFFL
IZZWLLLL
--------------------------------------------------------------------------------
UUUTLLLL
UXUTTTFL
XXXTFFFW
IXN  FWW
IYN  WWZ
IYNNVZZZ
IYYNVZPP
IYVVVPPP
--------------------------------------------------------------------------------
UUUYYYYF
UXUZYFFF
XXXZZZFW
PXV  ZWW
PPV  WWT
PPVVVTTT
LLLLNNNT
LIIIIINN
--------------------------------------------------------------------------------
UUUIIIII
UXUPPPWW
XXXPPWWY
NXF  WYY
NFF  ZZY
NNFFTVZY
LNTTTVZZ
LLLLTVVV
--------------------------------------------------------------------------------
UUUIIIII
UXUZYYYY
XXXZZZYW
NXF  ZWW
NFF  WWP
NNFFTVPP
LNTTTVPP
LLLLTVVV
--------------------------------------------------------------------------------
IIIIIVVV
LLLLNNFV
LXNNNFFV
XXX  ZFF
YXT  ZZZ
YYTTTWWZ
YUTUPPWW
YUUUPPPW
--------------------------------------------------------------------------------
IIIIIVVV
LLLLNNFV
LXNNNFFV
XXX  ZFF
YXT  ZZZ
YYTTTWWZ
YUTUWWPP
YUUUWPPP
--------------------------------------------------------------------------------
TIIIIINN
TTTYNNNW
TXYYYYWW
XXX  WWZ
LXF  ZZZ
LFFFUZUV
LFPPUUUV
LLPPPVVV
--------------------------------------------------------------------------------
TNNNYYYY
TTTNNLYW
TXLLLLWW
XXX  WWI
UXU  ZZI
UUUFFZVI
PPFFZZVI
PPPFVVVI
--------------------------------------------------------------------------------
TYYYYUUI
TTTYNNUI
TXNNNUUI
XXX  PPI
LXF  PPI
LWFFFPZV
LWWFZZZV
LLWWZVVV
--------------------------------------------------------------------------------
TYYYYUUI
TTTYNNUI
TXNNNUUI
XXX  PPI
WXF  PPI
WWFFFPZV
LWWFZZZV
LLLLZVVV
--------------------------------------------------------------------------------
IIIIIVVV
UUUPPPFV
UXUPPFFV
XXX  ZFF
YXT  ZZZ
YYTTTWWZ
YLTNNNWW
YLLLLNNW
--------------------------------------------------------------------------------
VVVFTUUU
VFFFTUNU
VXFTTTNI
XXX  NNI
LXP  NWI
LPPZZWWI
LPPZWWYI
LLZZYYYY
--------------------------------------------------------------------------------
VVVFLLLL
VFFFLYUU
VXFYYYYU
XXX  ZUU
PXT  ZZZ
PPTTTWWZ
PPTNNNWW
IIIIINNW
--------------------------------------------------------------------------------
VVVFUUUL
VFFFUYUL
VXFYYYYL
XXX  ZLL
PXT  ZZZ
PPTTTWWZ
PPTNNNWW
IIIIINNW
--------------------------------------------------------------------------------
VVVFZZWW
VFFFZWWL
VXFZZWNL
XXX  NNL
PXT  NLL
PPTTTNUU
PPTYYYYU
IIIIIYUU
--------------------------------------------------------------------------------
VVVFLLLL
VFFFLNNW
VXFNNNWW
XXX  WWZ
PXT  ZZZ
PPTTTZUU
PPTYYYYU
IIIIIYUU
--------------------------------------------------------------------------------
VVVFZZWW
VFFFZWWN
VXFZZWNN
XXX  YNI
PXT  YNI
PPTTTYYI
PPTLUYUI
LLLLUUUI
--------------------------------------------------------------------------------
VVVFZZWW
VFFFZWWN
VXFZZWNN
XXX  TNI
UXU  TNI
UUUYTTTI
LYYYYPPI
LLLLPPPI
--------------------------------------------------------------------------------
VVVFZZWW
VFFFZWWN
VXFZZWNN
XXX  TNL
UXU  TNL
UUUYTTTL
PPYYYYLL
PPPIIIII
--------------------------------------------------------------------------------
VVVFZZWW
VFFFZWWN
VXFZZWNN
XXX  TNI
UXU  TNI
UUUYTTTI
PPYYYYLI
PPPLLLLI
--------------------------------------------------------------------------------
VVVZZUUU
VPPPZUYU
VXPPZZYI
XXX  YYI
LXF  NYI
LWFFFNTI
LWWFNNTI
LLWWNTTT
--------------------------------------------------------------------------------
VVVZZUUU
VPPPZUYU
VXPPZZYI
XXX  YYI
WXF  NYI
WWFFFNTI
LWWFNNTI
LLLLNTTT
--------------------------------------------------------------------------------
VVVIIIII
VNNYYYYW
VXNNNYWW
XXX  WWZ
LXP  ZZZ
LPPTFZUU
LPPTFFFU
LLTTTFUU
--------------------------------------------------------------------------------
VVVIIIII
VYYYYNNW
VXYNNNWW
XXX  WWZ
LXP  ZZZ
LPPTFZUU
LPPTFFFU
LLTTTFUU
--------------------------------------------------------------------------------
IUUUPTTT
IUXUPPTY
IXXXPPTY
IFX  WYY
IFF  WWY
FFNNVZWW
NNNLVZZZ
LLLLVVVZ
--------------------------------------------------------------------------------
IUUUVVVZ
IUXUVZZZ
IXXXVZWW
IFX  WWY
IFF  WYY
FFNNPPTY
NNNLPPTY
LLLLPTTT
--------------------------------------------------------------------------------
IUUUPPPY
IUXUWPPY
IXXXWWYY
IFX  WWY
IFF  TLL
FFZTTTVL
ZZZNNTVL
ZNNNVVVL
--------------------------------------------------------------------------------
IUUUYYYY
IUXUWYPP
IXXXWWPP
IFX  WWP
IFF  TLL
FFZTTTVL
ZZZNNTVL
ZNNNVVVL
--------------------------------------------------------------------------------
IUUULLLL
IUXULNNN
IXXXNNWW
IFX  WWY
IFF  WYY
FFZVPPTY
ZZZVPPTY
ZVVVPTTT
--------------------------------------------------------------------------------
IUUUPTTT
IUXUPPTY
IXXXPPTY
IFX  WYY
IFF  WWY
FFZVNNWW
ZZZVLNNN
ZVVVLLLL
--------------------------------------------------------------------------------
IUUUPTTT
IUXUPPTV
IXXXPPTV
IFX  VVV
IFF  NLL
FFZWWNNL
ZZZYWWNL
ZYYYYWNL
--------------------------------------------------------------------------------
IUUUPVVV
IUXUPPTV
IXXXPPTV
IFX  TTT
IFF  NLL
FFZWWNNL
ZZZYWWNL
ZYYYYWNL
--------------------------------------------------------------------------------
IUUUTVVV
IUXUTTTV
IXXXTPPV
IFX  PPP
IFF  NLL
FFZWWNNL
ZZZYWWNL
ZYYYYWNL
--------------------------------------------------------------------------------
IUUUVVVT
IUXUVTTT
IXXXVPPT
IFX  PPP
IFF  NLL
FFZWWNNL
ZZZYWWNL
ZYYYYWNL
--------------------------------------------------------------------------------
IUUUPTTT
IUXUPPTY
IXXXPPTY
INX  WYY
INF  WWY
NNFFVZWW
NFFLVZZZ
LLLLVVVZ
--------------------------------------------------------------------------------
IUUUVVVZ
IUXUVZZZ
IXXXVZWW
INX  WWY
INF  WYY
NNFFPPTY
NFFLPPTY
LLLLPTTT
--------------------------------------------------------------------------------
IUUULLLL
IUXULVVV
IXXXTTTV
IWX  TNV
IWW  TNN
PPWWFZZN
PPYFFFZN
PYYYYFZZ
--------------------------------------------------------------------------------
IUUUPTTT
IUXUPPTY
IXXXPPTY
IWX  FYY
IWW  FFY
NNWWFFZV
LNNNZZZV
LLLLZVVV
--------------------------------------------------------------------------------
IUUUZVVV
IUXUZZZV
IXXXFFZV
IWX  FFY
IWW  FYY
NNWWPPTY
LNNNPPTY
LLLLPTTT
--------------------------------------------------------------------------------
IUUULLLL
IUXUNNNL
IXXXFFNN
IWX  FFY
IWW  FYY
VZWWPPTY
VZZZPPTY
VVVZPTTT
--------------------------------------------------------------------------------
IUUULLLL
IUXUNFFL
IXXXNNFF
IWX  NFY
IWW  NYY
VZWWPPTY
VZZZPPTY
VVVZPTTT
--------------------------------------------------------------------------------
IUUUPTTT
IUXUPPTY
IXXXPPTY
IWX  FYY
IWW  FFY
VZWWFFNN
VZZZNNNL
VVVZLLLL
--------------------------------------------------------------------------------
IUUUPTTT
IUXUPPTY
IXXXPPTY
IWX  NYY
IWW  NFY
VZWWNNFF
VZZZNFFL
VVVZLLLL
--------------------------------------------------------------------------------
LUUUPTTT
LUXUPPTY
LXXXPPTY
LLX  WYY
VVV  WWY
VZZFNNWW
VZFFFNNN
ZZFIIIII
--------------------------------------------------------------------------------
LUUUVVVZ
LUXUVZZZ
LXXXVZFF
LLX  FFI
PPP  NFI
TPPWWNNI
TTTYWWNI
TYYYYWNI
--------------------------------------------------------------------------------
PPIIIIIT
PPXNNTTT
PXXXNNNT
FFX  VVV
YFF  UUV
YFZZWWUV
YYZWWUUL
YZZWLLLL
--------------------------------------------------------------------------------
PPWWFFUU
PPXWWFFU
PXXXWFUU
LLX  VVV
LZZ  NNV
LTZNNNYV
LTZZYYYY
TTTIIIII
--------------------------------------------------------------------------------
PPWWYYYY
PPXWWYFF
PXXXWFFI
LLX  NFI
LZZ  NNI
LTZUUVNI
LTZZUVNI
TTTUUVVV
--------------------------------------------------------------------------------
YYYYLLLL
IYXWWFFL
IXXXWWFF
INX  WFZ
INN  ZZZ
IPNTUZUV
PPNTUUUV
PPTTTVVV
--------------------------------------------------------------------------------
YYYYFVVV
NYXFFZZV
NXXXFFZV
NNX  TZZ
UNU  TTT
UUULWTPP
LLLLWWPP
IIIIIWWP
--------------------------------------------------------------------------------
Total number of solutions found: 520
Number of unique solutions found: 65
```
